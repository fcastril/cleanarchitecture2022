using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string> // Administrador del Sistema
                {
                    RoleId = "5afedb4e-b4e1-4158-a2fd-8e658cd02a21",
                    UserId = "d247ab89-bddf-4928-801a-3407a082c053"
                }
            );
        }
    }
}
