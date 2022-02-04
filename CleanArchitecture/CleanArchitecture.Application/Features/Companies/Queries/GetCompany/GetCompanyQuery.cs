using CleanArchitecture.Application.ViewModels;
using MediatR;

namespace CleanArchitecture.Application.Features.Companies.Queries.GetCompaniesList
{
    public class GetCompanyQuery : IRequest<Company>
    {
        public string Code { get; set; } = string.Empty;

        public GetCompanyQuery(string code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }
    }
}
