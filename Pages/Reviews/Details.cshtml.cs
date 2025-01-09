using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Reviews
{
    public class DetailsModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;
        public readonly IStringLocalizer _localizer;

        public DetailsModel(Testare_TravelingAppContext context, IStringLocalizerFactory localizerFactory)
        {
            _context = context;
            _localizer = localizerFactory.Create("Resources", "Testare_TravelingApp");
        }

        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Review
                .Include(r => r.User)
                .Include(r => r.Activity)
                .Include(r => r.NatureTrail)
                .Include(r => r.Restaurant)
                .Include(r => r.TouristAttraction)
                .FirstOrDefaultAsync(m => m.ReviewId == id);

            if (Review == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
