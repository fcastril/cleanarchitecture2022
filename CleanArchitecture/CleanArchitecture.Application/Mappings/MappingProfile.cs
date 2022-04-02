using CleanArchitecture.Application.DTO;
using CleanArchitecture.Application.Features.Options.Commands.CreateOpion;
using CleanArchitecture.Application.Features.Options.Commands.UpdateOption;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Option, OptionDto>();
            CreateMap<CreateOptionCommand, Option>().ReverseMap();
            CreateMap<UpdateOptionCommand, Option>().ReverseMap();
        }
    }
}
