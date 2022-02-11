using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;


namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
