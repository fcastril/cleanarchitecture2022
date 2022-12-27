using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class OptionRepository : BaseRepository<Option>, IOptionRepository
    {
        public OptionRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
