using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Testare_TravelingApp.Data;  // Adăugăm referința la contextul bazei de date
using Testare_TravelingApp.Models; // Adăugăm referința la modelul User
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly Testare_TravelingAppContext _context; // Adăugăm contextul pentru a interacționa cu User

        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, Testare_TravelingAppContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context; // Inițializăm contextul
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    // După succesul autentificării, adăugăm utilizatorul în tabela User
                    var user = await _signInManager.UserManager.FindByEmailAsync(Input.Email);
                    var existingUser = await _context.User
                        .FirstOrDefaultAsync(u => u.Email == Input.Email);

                    if (existingUser == null)
                    {
                        // Creăm un nou utilizator dacă nu există în baza de date
                        var newUser = new User
                        {
                            UserName = user.UserName,
                            Email = Input.Email
                        };

                        _context.User.Add(newUser);
                        await _context.SaveChangesAsync();
                    }

                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }
    }
}
