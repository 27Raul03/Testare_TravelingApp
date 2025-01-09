using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.NatureTrails
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

        public IList<NatureTrail> NatureTrail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            NatureTrail = await _context.NatureTrail.ToListAsync();
        }
    }
}
