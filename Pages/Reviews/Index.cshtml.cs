using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;
        public readonly IStringLocalizer _localizer;

        public IndexModel(Testare_TravelingAppContext context, IStringLocalizerFactory localizerFactory)
        {
            _context = context;
            _localizer = localizerFactory.Create("Resources", "Testare_TravelingApp");
        }

        public IList<Review> Review { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Review = await _context.Review
                .Include(r => r.Activity)
                .Include(r => r.NatureTrail)
                .Include(r => r.Restaurant)
                .Include(r => r.TouristAttraction)
                .Include(r => r.User)
                .ToListAsync();
        }
    }
}
