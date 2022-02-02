using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Data.Common.ModelCreating
{
    public static class Profile
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Profile>()
                .HasMany(m => m.UserCompanyProfiles)
                .WithOne(m => m.Profile)
                .HasForeignKey(m => m.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
