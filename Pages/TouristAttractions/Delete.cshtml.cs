using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.TouristAttractions
{
    public class DeleteModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;

        public DeleteModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TouristAttraction TouristAttraction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristattraction = await _context.TouristAttraction.FirstOrDefaultAsync(m => m.TouristAttractionId == id);

            if (touristattraction == null)
            {
                return NotFound();
            }
            else
            {
                TouristAttraction = touristattraction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touristattraction = await _context.TouristAttraction.FindAsync(id);
            if (touristattraction != null)
            {
                TouristAttraction = touristattraction;
                _context.TouristAttraction.Remove(TouristAttraction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
