using Application.DTO;
using Application.Features.Options.Commands.CreateOpion;
using Application.Features.Options.Commands.UpdateOption;
using Domain.Entities;

namespace Application.Mappings
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
