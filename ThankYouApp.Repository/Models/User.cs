using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThankYouApp.Repository.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Index(IsUnique = true)]
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}
