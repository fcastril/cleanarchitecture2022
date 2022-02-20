using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "d247ab89-bddf-4928-801a-3407a082c053",
                    Email = "fcastril@gmail.com",
                    NormalizedEmail = "fcastril@gmail.com",
                    Name = "Administrador del Sistema",
                    UserName = "admon",
                    NormalizedUserName = "admon",
                    PasswordHash = hasher.HashPassword(null, "**F4b14n2022**"),
                    EmailConfirmed = true
                }
           ); ;
        }
    }
}
