using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Agendas
{
    public class EditModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;

        public EditModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Agenda Agenda { get; set; } = default!;

        // Se apelează atunci când pagina de editare este accesată pentru a obține agenda.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Căutăm agenda în baza de date folosind id-ul
            var agenda = await _context.Agenda.FirstOrDefaultAsync(m => m.AgendaId == id);
            if (agenda == null)
            {
                return NotFound();
            }

            // Setăm agenda pentru a fi disponibilă în pagina de editare
            Agenda = agenda;

            // Populăm dropdown-urile pentru a fi folosite în formularul de editare
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            ViewData["ActivityId"] = new SelectList(_context.Set<Activity>(), "ActivityId", "Name");
            ViewData["NatureTrailId"] = new SelectList(_context.Set<NatureTrail>(), "NatureTrailId", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "RestaurantId", "Name");
            ViewData["TouristAttractionId"] = new SelectList(_context.Set<TouristAttraction>(), "TouristAttractionId", "Name");

            return Page();
        }

        // Metoda care se apelează atunci când formularul este trimis pentru a salva modificările.
        public async Task<IActionResult> OnPostAsync()
        {

            // Actualizăm agenda în contextul bazei de date
            _context.Attach(Agenda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(Agenda.AgendaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        // Verifică dacă o agenda există în baza de date
        private bool AgendaExists(int id)
        {
            return _context.Agenda.Any(e => e.AgendaId == id);
        }
    }
}
