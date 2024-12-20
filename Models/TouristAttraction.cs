using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Models
{
    public class TouristAttraction
    {
        [Key]
        public int TouristAttractionId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public string OpeningHours { get; set; }

        // Navigation Properties
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<AgendaActivity>? AgendaActivities { get; set; } 
    }
}
