using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Agendas
{
    public class IndexModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        // Constructorul care primește contextul bazei de date și managerul de utilizatori
        public IndexModel(Testare_TravelingAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Agenda> Agenda { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Obține utilizatorul logat
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                // Filtrează agendele pe baza UserId-ului utilizatorului logat
                Agenda = await _context.Agenda
                    .Include(r => r.Activity)
                    .Include(r => r.NatureTrail)
                    .Include(r => r.Restaurant)
                    .Include(r => r.TouristAttraction)
                    .Include(r => r.User)
                    .Where(a => a.User.Email == user.Email)
                    .ToListAsync();
            }
            else
            {
                // Dacă utilizatorul nu este logat, returnează un set de date gol
                Agenda = new List<Agenda>();
            }
        }
    }
}
