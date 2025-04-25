using Microsoft.EntityFrameworkCore;
using WatherApp.Entity.Entities;

namespace WatherApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
    }
}
