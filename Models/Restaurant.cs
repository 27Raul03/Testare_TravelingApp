using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Cuisine { get; set; }

        // Navigation Properties
        public ICollection<Review> Reviews { get; set; }
        public ICollection<AgendaActivity> AgendaActivities { get; set; } // Many-to-Many
    }
}
