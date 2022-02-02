using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data.Common
{
    public partial class MainContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=P-FCASTRILLON\SQLSERVER2019;
                                          Initial Catalog=DbBase;
                                          Integrated Security=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelCreating.User.OnModelCreating(modelBuilder);
            ModelCreating.Profile.OnModelCreating(modelBuilder);
        }
    }
}
