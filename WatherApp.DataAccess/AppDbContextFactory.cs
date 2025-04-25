using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatherApp.DataAccess
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Buraya kendi veritabanı bağlantı stringini yaz!
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WatherAppDb;Trusted_Connection=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
