using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUserCompanyProfileRepository : IAsyncRepository<UserCompanyProfile>
    {
        Task<IEnumerable<UserCompanyProfile>> GetUserCompanyProfileByUserIdAndCompanyIdAsync(Guid userId, Guid companyId);
    }
}
