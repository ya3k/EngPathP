using Application.ServiceContracts;
using Application.ServiceContracts.Auth;
using Domain.Constants;
using Domain.Identity;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EPDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure")));


            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<EPDbContext>()
            .AddDefaultTokenProviders()
            .AddUserStore<UserStore<ApplicationUser, ApplicationRole, EPDbContext, Guid>>()
            .AddRoleStore<RoleStore<ApplicationRole, EPDbContext, Guid>>();



            services.AddTransient<IJwtService, JwtService>();
            services.AddScoped<IAuthService, AuthService>();


            // authorization policies

            services.AddAuthentication(item =>
            {
                item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    RoleClaimType = ClaimTypes.Role
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(ApplicationConst.AuthenticatedUser,
                policy => policy.RequireAuthenticatedUser());
                options.AddPolicy(ApplicationConst.AdminPermission,
                    policy => policy.RequireRole(ApplicationRole.ADMIN));
                options.AddPolicy(ApplicationConst.UserPermission,
                    policy => policy.RequireRole(ApplicationRole.USER, ApplicationRole.ADMIN));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("all", corsPolicyBuilder => corsPolicyBuilder
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            });

        }
    }
}
