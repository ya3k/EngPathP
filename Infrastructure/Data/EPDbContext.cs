using Domain.Entity;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
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

        //learning path
        public DbSet<LearningPath> learningPaths { get; set; }
        public DbSet<LearnModule> learnModules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        //content
        public DbSet<Vocabulary> Vocabularies { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<VocabularySet> VocabularySets { get; set; }
        public DbSet<VocabularySetItem> VocabularySetItems { get; set; }
        public DbSet<GrammarTopic> GrammarTopics { get; set; }

        //user process
        public DbSet<UserProgress> UserProgresses { get; set; }
        public DbSet<UserVocabulary> UserVocabularies { get; set; }
        public DbSet<UserLearningPath> UserLearningPaths { get; set; }





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
            var hasher = new PasswordHasher<ApplicationUser>();

            // Seed default admin user
            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   Id = Guid.Parse("e4eaaaf2-d142-11e1-b3e4-080027620cdd"),
                   UserName = "admin",
                   NormalizedUserName = "ADMIN",
                   Email = "van23@example.com",
                   NormalizedEmail = "VAN23@EXAMPLE.COM",
                   EmailConfirmed = true,
                   PasswordHash = hasher.HashPassword(null, "23012003aA@"),
                   SecurityStamp = Guid.NewGuid().ToString("D"),
                   ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                   IsActive = true,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               }
            );

            modelBuilder.Entity<VocabularySetItem>()
      .HasKey(vsi => new { vsi.VocabularySetId, vsi.VocabularyId });

            modelBuilder.Entity<VocabularySetItem>()
                .HasOne(vsi => vsi.Vocabulary)
                .WithMany(v => v.VocabularySetItems)
                .HasForeignKey(vsi => vsi.VocabularyId);

            modelBuilder.Entity<VocabularySetItem>()
                .HasOne(vsi => vsi.VocabularySet)
                .WithMany(vs => vs.VocabularySetItems)
                .HasForeignKey(vsi => vsi.VocabularySetId);

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
