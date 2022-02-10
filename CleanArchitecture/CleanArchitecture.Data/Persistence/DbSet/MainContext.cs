using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public partial class MainContext : DbContext
    {
        public DbSet<Company>? Companies { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Option>? Options { get; set; }
        public DbSet<OptionSecurity>? OptionSecurities { get; set; }
        public DbSet<Profile>? Profiles { get; set; }
        public DbSet<UserCompanyProfile>? UserCompanyProfiles { get; set; }
    }
}
