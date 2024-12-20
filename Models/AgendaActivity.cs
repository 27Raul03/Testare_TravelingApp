using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Models
{
    public class AgendaActivity
    {
        [Key]
        public int AgendaActivityId { get; set; }

        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }

        public int? ActivityId { get; set; }
        public Activity? Activity { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        public int? NatureTrailId { get; set; }
        public NatureTrail? NatureTrail { get; set; }

        public int? TouristAttractionId { get; set; }
        public TouristAttraction? TouristAttraction { get; set; }
    }
}
