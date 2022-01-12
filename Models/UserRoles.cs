namespace Hostitan.API.Models
{
    public class UserRoles
    {
        public int userId { get; set; }
        public User user { get; set; }
        public int RoleId { get; set; }
        public roles role { get; set; }
    }
}