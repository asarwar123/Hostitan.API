using System.ComponentModel.DataAnnotations;

namespace Hostitan.API.Models
{
    public class roles
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; } = true;
        List<User> user {get;set;}
    }
}