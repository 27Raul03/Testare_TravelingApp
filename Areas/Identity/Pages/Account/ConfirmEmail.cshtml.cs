// ConfirmEmailModel.cs
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace Testare_TravelingApp.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ConfirmEmailModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        // OnGetAsync va confirma email-ul și va redirecționa utilizatorul la /Users/Create dacă succesul este obținut
        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index"); // Dacă parametrii lipsesc, redirecționează la pagina principală
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code)); // Decodifică token-ul de confirmare

            var result = await _userManager.ConfirmEmailAsync(user, code);

            // Setează mesajul de status în funcție de rezultatul confirmării
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";

            // Dacă confirmarea a fost cu succes, redirecționează la pagina de completare a profilului
            if (result.Succeeded)
            {
                return RedirectToPage("./Login"); // Redirecționează la pagina de completare a profilului
            }

            // Dacă confirmarea a eșuat, rămâi pe aceeași pagină și afișează mesajul de eroare
            return Page();
        }
    }
}
