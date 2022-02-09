using CleanArchitecture.Application.DTO;
using CleanArchitecture.Application.Features.Options.Commands.CreateOpion;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CreateOptionCommand, Option>();
        }
    }
}
