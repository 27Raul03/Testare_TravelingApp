using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Testare_TravelingApp.Data;
using Testare_TravelingApp.Models;

namespace Testare_TravelingApp.Pages.Activities
{
    public class CreateModel : PageModel
    {
        private readonly Testare_TravelingAppContext _context;
        private readonly IStringLocalizer _localizer;

        public CreateModel(Testare_TravelingAppContext context, IStringLocalizerFactory localizerFactory)
        {
            _context = context;
            _localizer = localizerFactory.Create("Resources", "Testare_TravelingApp");
        }

        [BindProperty]
        public Activity Activity { get; set; } = default!;

        public string CreateActivityTitle { get; private set; } = string.Empty;
        public string ActivityHeader { get; private set; } = string.Empty;
        public string ActivityName { get; private set; } = string.Empty;
        public string ActivityDescription { get; private set; } = string.Empty;
        public string ActivityLocation { get; private set; } = string.Empty;
        public string ActivityStartDate { get; private set; } = string.Empty;
        public string ActivityEndDate { get; private set; } = string.Empty;
        public string CreateButton { get; private set; } = string.Empty;
        public string BackToList { get; private set; } = string.Empty;

        public void OnGet()
        {
            CreateActivityTitle = _localizer["CreateActivity"];
            ActivityHeader = _localizer["ActivityPage"];
            ActivityName = _localizer["ActivityName"];
            ActivityDescription = _localizer["ActivityDescription"];
            ActivityLocation = _localizer["ActivityLocation"];
            ActivityStartDate = _localizer["ActivityStartDate"];
            ActivityEndDate = _localizer["ActivityEndDate"];
            CreateButton = _localizer["CreateButton"];
            BackToList = _localizer["BackToList"];
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Activity.Add(Activity);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
