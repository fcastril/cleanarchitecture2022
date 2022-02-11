using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UserCompanyProfileRepository : BaseRepository<UserCompanyProfile>, IUserCompanyProfileRepository
    {
        public UserCompanyProfileRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
