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

        public ICollection<AgendaActivity>? AgendaActivities { get; set; } // Many-to-Many
    }
}
