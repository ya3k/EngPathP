using Domain.Entity;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EPDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public EPDbContext(DbContextOptions options) : base(options)
        {

        }

        public EPDbContext() { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EPDbContext).Assembly);

            // Seed default roles
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = ApplicationRole.ADMIN,
                    NormalizedName = ApplicationRole.ADMIN.ToUpper()
                },
                new ApplicationRole
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = ApplicationRole.USER,
                    NormalizedName = ApplicationRole.USER.ToUpper()
                }
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            //configurationBuilder.RegisterAllInVogenEfCoreConverters();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<ApplicationUser>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }

}
