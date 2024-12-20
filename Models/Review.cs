using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

        // Foreign Keys and Navigation Properties
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Activity")]
        public int? ActivityId { get; set; }
        public Activity? Activity { get; set; }

        [ForeignKey("Restaurant")]
        public int? RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        [ForeignKey("NatureTrail")]
        public int? NatureTrailId { get; set; }
        public NatureTrail? NatureTrail { get; set; }

        [ForeignKey("TouristAttraction")]
        public int? TouristAttractionId { get; set; }
        public TouristAttraction? TouristAttraction { get; set; }
    }
}
