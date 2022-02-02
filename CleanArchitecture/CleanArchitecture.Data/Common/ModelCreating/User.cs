using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data.Common.ModelCreating
{
    public static class User
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.User>()
               .HasMany(m => m.ProfilesCreated)
               .WithOne(m => m.UserCreated)
               .HasForeignKey(m => m.UserCreatedId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Domain.Entities.User>()
                 .HasMany(m => m.ProfilesUpdated)
                 .WithOne(m => m.UserUpdated)
                 .HasForeignKey(m => m.UserUpdatedId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Domain.Entities.User>()
                 .HasMany(m => m.UserCompanyProfiles)
                 .WithOne(m => m.User)
                 .HasForeignKey(m => m.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}