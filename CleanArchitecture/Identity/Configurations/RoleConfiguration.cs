using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "5afedb4e-b4e1-4158-a2fd-8e658cd02a21",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                new IdentityRole
                {
                    Id = "56078f8f-b913-4813-a271-6feb74ae5957",
                    Name = "Invitado",
                    NormalizedName = "Invitado"
                }
            );
        }
    }
}
