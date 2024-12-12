using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        // Navigation Properties
        public ICollection<Review> Reviews { get; set; }
        public ICollection<AgendaActivity> AgendaActivities { get; set; } // Many-to-Many
    }
}
