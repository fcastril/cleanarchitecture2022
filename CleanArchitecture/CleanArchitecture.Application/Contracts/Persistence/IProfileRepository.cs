using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        Task<IBaseRepository<Profile>> GetProfilesByCompanyIdAsync(Guid companyId);
    }
}
