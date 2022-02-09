using CleanArchitecture.Application.DTO;
using MediatR;

namespace CleanArchitecture.Application.Features.Companies.Queries.GetCompaniesList
{
    public class GetCompanyByCodeQuery : IRequest<CompanyDto>
    {
        public string Code { get; set; } = string.Empty;

        public GetCompanyByCodeQuery(string code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
}
