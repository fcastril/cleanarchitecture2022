using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.DTO;
using MediatR;

namespace CleanArchitecture.Application.Features.Companies.Queries.GetCompaniesList
{
    public class GetCompanyByCodeQueryHandler : IRequestHandler<GetCompanyByCodeQuery, CompanyDto>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyByCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDto> Handle(GetCompanyByCodeQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList< Domain.Entities.Company > companies = await _companyRepository.GetAsync(c => c.Code == request.Code);

            return _mapper.Map<CompanyDto>(companies.FirstOrDefault());

        }
    }
}
