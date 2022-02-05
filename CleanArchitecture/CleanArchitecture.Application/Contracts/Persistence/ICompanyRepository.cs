using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<Company> GetCompanyByCodeAsync(string Code);
    }
}
