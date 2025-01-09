using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Testare_TravelingApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IStringLocalizer _localizer;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IStringLocalizerFactory localizerFactory)
        {
            _logger = logger;
            _localizer = localizerFactory.Create("Resources", "Testare_TravelingApp");
        }

        public string WelcomeMessage { get; private set; } = string.Empty;
        public string SubText { get; private set; } = string.Empty;
        public string StartPlanningText { get; private set; } = string.Empty;
        public string ItineraryPlanning { get; private set; } = string.Empty;
        public string ItineraryDescription { get; private set; } = string.Empty;
        public string TravelGuides { get; private set; } = string.Empty;
        public string TravelGuidesDescription { get; private set; } = string.Empty;
        public string TrackProgress { get; private set; } = string.Empty;
        public string TrackProgressDescription { get; private set; } = string.Empty;
        public string WhyChooseTitle { get; private set; } = string.Empty;
        public string WhyChooseDescription { get; private set; } = string.Empty;

        public void OnGet()
        {
            WelcomeMessage = _localizer["WelcomeMessage"];
            SubText = _localizer["SubText"];
            StartPlanningText = _localizer["StartPlanningText"];
            ItineraryPlanning = _localizer["ItineraryPlanning"];
            ItineraryDescription = _localizer["ItineraryDescription"];
            TravelGuides = _localizer["TravelGuides"];
            TravelGuidesDescription = _localizer["TravelGuidesDescription"];
            TrackProgress = _localizer["TrackProgress"];
            TrackProgressDescription = _localizer["TrackProgressDescription"];
            WhyChooseTitle = _localizer["WhyChooseTitle"];
            WhyChooseDescription = _localizer["WhyChooseDescription"];
        }
    }
}
