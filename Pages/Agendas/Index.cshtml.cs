﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Agendas
{
    public class IndexModel : PageModel
    {
        private readonly Testare_TravelingApp.Data.Testare_TravelingAppContext _context;

        public IndexModel(Testare_TravelingApp.Data.Testare_TravelingAppContext context)
        {
            _context = context;
        }

        public IList<Agenda> Agenda { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Agenda = await _context.Agenda
                .Include(r => r.Activity)
                .Include(r => r.NatureTrail)
                .Include(r => r.Restaurant)
                .Include(r => r.TouristAttraction)
                .Include(r => r.User).ToListAsync();
        }
    }
}
