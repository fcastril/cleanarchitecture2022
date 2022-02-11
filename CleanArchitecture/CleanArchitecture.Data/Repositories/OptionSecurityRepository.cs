using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class OptionSecurityRepository : BaseRepository<OptionSecurity>, IOptionSecurityRepository
    {
        public OptionSecurityRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
