using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Agendas
{
    public class DetailsModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;

        public DetailsModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context)
        {
            _context = context;
        }

        public Agenda Agenda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Căutăm agenda pe baza ID-ului și includem doar entitățile asociate relevante
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
