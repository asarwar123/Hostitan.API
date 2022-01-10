using System.ComponentModel.DataAnnotations;

namespace Hostitan.API.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string fullName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public byte[] passwordHash { get; set; }
        [Required]
        public byte[] passwordSalt { get; set; }
        public List<roles> userRoles { get; set; }
    }
}