using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Agendas
{
    public class CreateModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;

        // Constructorul care primește contextul bazei de date
        public CreateModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context)
        {
            _context = context;
        }

        // Metoda care se apelează la accesarea paginii pentru a încărca drop-down-urile
        public IActionResult OnGet()
        {
            PopulateDropdowns();
            return Page();
        }

        [BindProperty]
        public Agenda Agenda { get; set; } = default!;

        // Reîncărcarea dropdown-urilor
        private void PopulateDropdowns()
        {
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            ViewData["ActivityId"] = new SelectList(_context.Set<Activity>(), "ActivityId", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "RestaurantId", "Name");
            ViewData["NatureTrailId"] = new SelectList(_context.Set<NatureTrail>(), "NatureTrailId", "Name");
            ViewData["TouristAttractionId"] = new SelectList(_context.Set<TouristAttraction>(), "TouristAttractionId", "Name");
        }

        // Metoda care se execută la postarea formularului
        public async Task<IActionResult> OnPostAsync()
        {   // Adăugăm agenda în contextul bazei de date
            _context.Agenda.Add(Agenda);
            await _context.SaveChangesAsync();

            // După salvare, redirecționăm utilizatorul la pagina cu lista de agende
            return RedirectToPage("./Index");
        }
    }
}
