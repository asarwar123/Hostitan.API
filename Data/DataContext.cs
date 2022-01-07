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
    }
}
