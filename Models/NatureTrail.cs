using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Models
{
    public class NatureTrail
    {
        [Key]
        public int NatureTrailId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public double LengthInKm { get; set; }

        // Navigation Properties
        public ICollection<Review> Reviews { get; set; }
        public ICollection<AgendaActivity> AgendaActivities { get; set; } // Many-to-Many
    }
}
