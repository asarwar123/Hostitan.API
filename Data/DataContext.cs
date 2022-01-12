using Hostitan.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostitan.API.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {            
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.userId, ur.RoleId });
        }
    }
}
