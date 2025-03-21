﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.NatureTrails
{
    public class EditModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;

        public EditModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context)
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

            var naturetrail =  await _context.NatureTrail.FirstOrDefaultAsync(m => m.NatureTrailId == id);
            if (naturetrail == null)
            {
                return NotFound();
            }
            NatureTrail = naturetrail;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NatureTrail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NatureTrailExists(NatureTrail.NatureTrailId))
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

        private bool NatureTrailExists(int id)
        {
            return _context.NatureTrail.Any(e => e.NatureTrailId == id);
        }
    }
}
