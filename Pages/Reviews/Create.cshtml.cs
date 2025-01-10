using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;
        public readonly IStringLocalizer _localizer;

        public CreateModel(Testare_TravelingAppContext context, IStringLocalizerFactory localizerFactory)
        {
            _context = context;
            _localizer = localizerFactory.Create("Resources", "Testare_TravelingApp");
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public IActionResult OnGet()
        {
            PopulateDropdowns();
            return Page();
        }

        private void PopulateDropdowns()
        {
            ViewData["ActivityId"] = new SelectList(_context.Set<Activity>(), "ActivityId", "Name");
            ViewData["NatureTrailId"] = new SelectList(_context.Set<NatureTrail>(), "NatureTrailId", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "RestaurantId", "Name");
            ViewData["TouristAttractionId"] = new SelectList(_context.TouristAttraction, "TouristAttractionId", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns();
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
