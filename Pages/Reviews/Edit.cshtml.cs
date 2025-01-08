using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .Include(r => r.User) // Include pentru a accesa email-ul
                .FirstOrDefaultAsync(m => m.ReviewId == id);

            if (review == null)
            {
                return NotFound();
            }

            // Obține utilizatorul logat
            var currentUser = await _userManager.GetUserAsync(User);

            // Verifică dacă utilizatorul logat are permisiunea de editare
            if (currentUser == null || review.User.Email != currentUser.Email)
            {
                return RedirectToPage("/Error", new { errorMessage = "Doar autorul review-ului poate edita" }); 
            }

            Review = review;
            ViewData["ActivityId"] = new SelectList(_context.Set<Activity>(), "ActivityId", "Name");
            ViewData["NatureTrailId"] = new SelectList(_context.Set<NatureTrail>(), "NatureTrailId", "Name");
            ViewData["RestaurantId"] = new SelectList(_context.Set<Restaurant>(), "RestaurantId", "Name");
            ViewData["TouristAttractionId"] = new SelectList(_context.TouristAttraction, "TouristAttractionId", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Obține review-ul din baza de date pentru verificare
            var review = await _context.Review
                .Include(r => r.User) // Include pentru a accesa email-ul
                .FirstOrDefaultAsync(m => m.ReviewId == Review.ReviewId);

            if (review == null)
            {
                return NotFound();
            }

            // Obține utilizatorul logat
            var currentUser = await _userManager.GetUserAsync(User);

            // Verifică dacă utilizatorul logat are permisiunea de editare
            if (currentUser == null || review.User.Email != currentUser.Email)
            {
                return Forbid(); // Sau return RedirectToPage("/Error", new { message = "Unauthorized access" });
            }

            _context.Attach(Review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.ReviewId))
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

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.ReviewId == id);
        }
    }
}