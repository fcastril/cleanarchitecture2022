using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IProfileRepository : IAsyncRepository<Profile>
    {
        Task<IAsyncRepository<Profile>> GetProfilesByCompanyIdAsync(Guid companyId);
    }
}
