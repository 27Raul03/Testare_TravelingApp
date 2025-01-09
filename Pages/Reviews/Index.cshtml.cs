using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;
using Microsoft.Extensions.Localization;


namespace Testare_TravelingApp.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;
        private readonly IStringLocalizer _localizer;

        public IndexModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context, IStringLocalizerFactory localizerFactory)
        {
            _context = context;
            _localizer = localizerFactory.Create("Resources", "Testare_TravelingApp");
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Review = await _context.Review
                .Include(r => r.Activity)
                .Include(r => r.NatureTrail)
                .Include(r => r.Restaurant)
                .Include(r => r.TouristAttraction)
                .Include(r => r.User).ToListAsync();
        }
    }
}
