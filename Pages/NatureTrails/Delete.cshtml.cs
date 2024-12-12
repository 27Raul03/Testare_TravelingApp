﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.NatureTrails
{
    public class DeleteModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;

        public DeleteModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NatureTrail NatureTrail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naturetrail = await _context.NatureTrail.FirstOrDefaultAsync(m => m.NatureTrailId == id);

            if (naturetrail == null)
            {
                return NotFound();
            }
            else
            {
                NatureTrail = naturetrail;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naturetrail = await _context.NatureTrail.FindAsync(id);
            if (naturetrail != null)
            {
                NatureTrail = naturetrail;
                _context.NatureTrail.Remove(NatureTrail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
