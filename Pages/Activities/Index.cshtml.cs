using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;
using Microsoft.Extensions.Localization;

namespace Testare_TravelingApp.Pages.Activities
{
    public class IndexModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;

        public IndexModel(Testare_TravelingAppContext context)
        {
            _context = context;
        }
        public string WelcomeMessage { get; private set; } = string.Empty;
        public IList<Activity> Activity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Activity = await _context.Activity.ToListAsync();
        }
    }
}
