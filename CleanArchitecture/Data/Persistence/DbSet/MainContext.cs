using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class MainContext : DbContext
    {
        public DbSet<Option>? Options { get; set; }
    }
}
