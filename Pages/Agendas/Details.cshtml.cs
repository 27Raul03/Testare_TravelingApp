using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Testare_TravelingApp.Pages.Agendas
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

        public Agenda Agenda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.User)
                .Include(a => a.Activity)
                .Include(a => a.NatureTrail)
                .Include(a => a.Restaurant)
                .Include(a => a.TouristAttraction)
                .FirstOrDefaultAsync(m => m.AgendaId == id);

            if (agenda == null)
            {
                return NotFound();
            }
            else
            {
                Agenda = agenda;
            }
            return Page();
        }
    }
}
