using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Models
{
    public class Agenda
    {
        [Key]
        public int AgendaId { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Foreign Keys and Navigation Properties
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Activity")]
        public int? ActivityId { get; set; } // Nullable if optional
        public Activity? Activity { get; set; }

        [ForeignKey("Restaurant")]
        public int? RestaurantId { get; set; } 
        public Restaurant? Restaurant { get; set; }

        [ForeignKey("TouristAttraction")]
        public int? TouristAttractionId { get; set; } 
        public TouristAttraction? TouristAttraction { get; set; }

        [ForeignKey("NatureTrail")]
        public int? NatureTrailId { get; set; } 
        public NatureTrail? NatureTrail { get; set; }

        public ICollection<AgendaActivity>? AgendaActivities { get; set; } // Many-to-Many
    }
}
