using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IOptionSecurityRepository : IBaseRepository<OptionSecurity>
    {
        Task<IEnumerable<OptionSecurity>> GetOptionSecuritiesByProfileIdAsync(Guid profileId);
        Task<OptionSecurity> GetOptionSecuritiesByProfileIdAndOptionIdAsync(Guid profileId, Guid optionId);
    }
}
