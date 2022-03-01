using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public partial class MainContext : DbContext
    {
        public DbSet<Option>? Options { get; set; }
    }
}
