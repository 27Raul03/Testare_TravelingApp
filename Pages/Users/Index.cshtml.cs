using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Users
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

        public IList<User> UserList { get; set; } = default!;
        public string CurrentUserEmail { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            CurrentUserEmail = User?.Identity?.Name ?? string.Empty;
            UserList = await _context.User.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var currentUserEmail = User?.Identity?.Name ?? string.Empty;
            var userToDelete = await _context.User.FindAsync(id);

            if (userToDelete == null)
            {
                return NotFound();
            }

            if (userToDelete.Email != currentUserEmail)
            {
                return Forbid();
            }

            _context.User.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
