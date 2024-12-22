using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Agendas
{
    public class CreateModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        // Constructorul care primește contextul bazei de date și UserManager pentru a obține utilizatorul curent
        public CreateModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
            ViewData["ActivityId"] = new SelectList(_context.Set<Activity>(), "ActivityId", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "RestaurantId", "Name");
            ViewData["NatureTrailId"] = new SelectList(_context.Set<NatureTrail>(), "NatureTrailId", "Name");
            ViewData["TouristAttractionId"] = new SelectList(_context.Set<TouristAttraction>(), "TouristAttractionId", "Name");
        }

        // Metoda care se execută la postarea formularului
        public async Task<IActionResult> OnPostAsync()
        {
            // Obține utilizatorul curent din contextul de autentificare
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                // Căutăm UserId-ul utilizatorului în baza de date pe baza email-ului
                var currentUser = _context.User.FirstOrDefault(u => u.Email == user.Email);

                if (currentUser != null)
                {
                    // Setăm UserId pentru agenda curentă
                    Agenda.UserId = currentUser.UserId;

                    // Adăugăm agenda în contextul bazei de date
                    _context.Agenda.Add(Agenda);
                    await _context.SaveChangesAsync();

                    // După salvare, redirecționăm utilizatorul la pagina cu lista de agende
                    return RedirectToPage("./Index");
                }
                else
                {
                    // Utilizatorul nu a fost găsit
                    ModelState.AddModelError("", "User not found");
                    return Page();
                }
            }

            // Dacă utilizatorul nu este autentificat
            ModelState.AddModelError("", "User not authenticated");
            return Page();
        }
    }
}
