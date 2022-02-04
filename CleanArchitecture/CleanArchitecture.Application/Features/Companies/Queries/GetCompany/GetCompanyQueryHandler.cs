using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.ViewModels;
using MediatR;

namespace CleanArchitecture.Application.Features.Companies.Queries.GetCompaniesList
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, Company>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Company> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Company company = await _companyRepository.GetCompanyByCodeAsync(request.Code);

            return _mapper.Map<Company>(company);

        }
    }
}
