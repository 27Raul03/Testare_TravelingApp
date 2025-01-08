using System.ComponentModel.DataAnnotations;

namespace Testare_TravelingApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        // Navigation Properties

       public ICollection<Review> Reviews { get; set; }
       /* public Agenda Agenda { get; set; } // 1:1 Relationship*/
    }
}
