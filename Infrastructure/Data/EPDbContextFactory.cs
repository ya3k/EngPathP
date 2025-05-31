using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Infrastructure.Data;

namespace Infrastructure.Data
{
    public class EPDbContextFactory : IDesignTimeDbContextFactory<EPDbContext>
    {
        public EPDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EPDbContext>();
            // Use your actual connection string here
            optionsBuilder.UseSqlServer("Server=localhost;Database=testCon;User Id=sa;Password=123;Trusted_Connection=True;TrustServerCertificate=True;");

            return new EPDbContext(optionsBuilder.Options);
        }
    }
}
