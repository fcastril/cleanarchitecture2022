using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public partial class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options): base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDateTime = DateTime.UtcNow;
                        entry.Entity.UpdatedDateTime = DateTime.UtcNow;
                        entry.Entity.State = true;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDateTime = DateTime.UtcNow;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<BaseGeneralEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDateTime = DateTime.UtcNow;
                        entry.Entity.UpdatedDateTime = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDateTime = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=P-FCASTRILLON\SQLSERVER2019;
        //                                  Initial Catalog=DbBase;
        //                                  Integrated Security=True")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelCreating.User.OnModelCreating(modelBuilder);
            ModelCreating.Profile.OnModelCreating(modelBuilder);
        }
    }
}
