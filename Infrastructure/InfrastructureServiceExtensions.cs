using Infrastructure.Common.Settings;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            var environmentSection = configuration.GetSection("Environment");

            var connectionString = environmentSection.GetConnectionString("DefaultConnection"); 
            var jwtSettings = environmentSection.GetSection("JwtSettings");
            //services.Configure<JwtSettings>(jwtSettings);

            services.AddDbContext<EPDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure")));



        }

    }
}
