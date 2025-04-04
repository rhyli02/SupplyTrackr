using System.ComponentModel.DataAnnotations;

namespace SupplyTrackr_Profile.Models
{
    public class Profiles

    {
   
        [Key]
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }

        public required string Account { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}

