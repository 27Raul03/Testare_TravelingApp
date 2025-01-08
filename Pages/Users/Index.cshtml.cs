using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;

        public IndexModel(Testare_TravelingAppContext context)
        {
            _context = context;
        }

        // Lista utilizatorilor din baza de date
        public IList<User> UserList { get; set; } = new List<User>();

        // Email-ul utilizatorului conectat
        public string CurrentUserEmail { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            // Obține email-ul utilizatorului conectat
            CurrentUserEmail = User?.Identity?.Name ?? string.Empty;

            // Obține lista utilizatorilor din baza de date
            UserList = await _context.User.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            // Obține email-ul utilizatorului conectat
            var currentUserEmail = User?.Identity?.Name ?? string.Empty;

            // Găsește utilizatorul care trebuie șters
            var userToDelete = await _context.User.FindAsync(id);

            if (userToDelete == null)
            {
                return NotFound();
            }

            // Verifică dacă email-ul utilizatorului conectat corespunde cu cel al utilizatorului care trebuie șters
            if (userToDelete.Email != currentUserEmail)
            {
                return Forbid();
            }

            // Șterge utilizatorul
            _context.User.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
