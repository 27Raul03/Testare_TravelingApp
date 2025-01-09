using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;
using Microsoft.Extensions.Localization;

namespace Testare_TravelingApp.Pages.Agendas
{
    public class CreateModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStringLocalizer _localizer;

        public CreateModel(Testare_TravelingAppContext context, UserManager<IdentityUser> userManager, IStringLocalizerFactory localizerFactory)
        {
            _context = context;
            _userManager = userManager;
            _localizer = localizerFactory.Create("Resources", "Testare_TravelingApp");
        }

        [BindProperty]
        public Agenda Agenda { get; set; } = default!;

        // Properties for localized strings
        public string CreateTitle { get; private set; } = string.Empty;
        public string AgendaLabel { get; private set; } = string.Empty;
        public string TitleLabel { get; private set; } = string.Empty;
        public string DateCreatedLabel { get; private set; } = string.Empty;
        public string ActivityLabel { get; private set; } = string.Empty;
        public string RestaurantLabel { get; private set; } = string.Empty;
        public string NatureTrailLabel { get; private set; } = string.Empty;
        public string TouristAttractionLabel { get; private set; } = string.Empty;
        public string SelectOption { get; private set; } = string.Empty;
        public string CreateButtonLabel { get; private set; } = string.Empty;
        public string BackToListLabel { get; private set; } = string.Empty;

        public IActionResult OnGet()
        {
            LoadLocalizedStrings();
            PopulateDropdowns();
            return Page();
        }

        private void LoadLocalizedStrings()
        {
            CreateTitle = _localizer["CreateTitle"];
            AgendaLabel = _localizer["AgendaLabel"];
            TitleLabel = _localizer["TitleLabel"];
            DateCreatedLabel = _localizer["DateCreatedLabel"];
            ActivityLabel = _localizer["ActivityLabel"];
            RestaurantLabel = _localizer["RestaurantLabel"];
            NatureTrailLabel = _localizer["NatureTrailLabel"];
            TouristAttractionLabel = _localizer["TouristAttractionLabel"];
            SelectOption = _localizer["SelectOption"];
            CreateButtonLabel = _localizer["CreateButtonLabel"];
            BackToListLabel = _localizer["BackToListLabel"];
        }

        private void PopulateDropdowns()
        {
            ViewData["ActivityId"] = new SelectList(_context.Set<Activity>(), "ActivityId", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "RestaurantId", "Name");
            ViewData["NatureTrailId"] = new SelectList(_context.Set<NatureTrail>(), "NatureTrailId", "Name");
            ViewData["TouristAttractionId"] = new SelectList(_context.Set<TouristAttraction>(), "TouristAttractionId", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var currentUser = _context.User.FirstOrDefault(u => u.Email == user.Email);

                if (currentUser != null)
                {
                    Agenda.UserId = currentUser.UserId;
                    _context.Agenda.Add(Agenda);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                else
                {
                    ModelState.AddModelError("", _localizer["UserNotFound"]);
                    return Page();
                }
            }

            ModelState.AddModelError("", _localizer["UserNotAuthenticated"]);
            return Page();
        }
    }
}
