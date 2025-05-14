using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
         
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EPDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure")));



        }

    }
}
