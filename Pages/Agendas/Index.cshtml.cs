using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;
using Microsoft.Extensions.Localization;


namespace Testare_TravelingApp.Pages.Agendas
{
    public class IndexModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;
        private readonly IStringLocalizer _localizer;
        private readonly UserManager<IdentityUser> _userManager;

        // Constructorul care primește contextul bazei de date și managerul de utilizatori
        public IndexModel(Testare_TravelingAppContext context, IStringLocalizerFactory localizerFactory, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _localizer = localizerFactory.Create("Resources", "Testare_TravelingApp");
            _userManager = userManager;
        }

        public IList<Agenda> Agenda { get; set; } = default!;

        public string YourAgenda { get; private set; } = string.Empty;
        public string AddActivityButon { get; private set; } = string.Empty;
        public string CreatedAt { get; private set; } = string.Empty;
        public string CreatedBy { get; private set; } = string.Empty;
        public string Activity { get; private set; } = string.Empty;
        public string StartingAt { get; private set; } = string.Empty;
        public string Restaurant { get; private set; } = string.Empty;
        public string NatureTrail { get; private set; } = string.Empty;
        public string Attraction { get; private set; } = string.Empty;
        public string Edit { get; private set; } = string.Empty;
        public string Details { get; private set; } = string.Empty;
        public string Delete { get; private set; } = string.Empty;
        public string NoAgendasFound { get; private set; } = string.Empty;

        public async Task OnGetAsync()
        {
            YourAgenda = _localizer["YourAgenda"];
            AddActivityButon = _localizer["AddActivityButon"];
            CreatedAt = _localizer["CreatedAt"];
            CreatedBy = _localizer["CreatedBy"];
            Activity = _localizer["Activity"];
            StartingAt = _localizer["StartingAt"];
            Restaurant = _localizer["Restaurant"];
            NatureTrail = _localizer["NatureTrail"];
            Attraction = _localizer["Attraction"];
            Edit = _localizer["Edit"];
            Details = _localizer["Details"];
            Delete = _localizer["Delete"];
            NoAgendasFound = _localizer["NoAgendasFound"];

            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
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
                Agenda = new List<Agenda>();
            }
        }
    }
}
