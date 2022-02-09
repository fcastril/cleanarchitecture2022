using CleanArchitecture.Application.DTO.Common;

namespace CleanArchitecture.Application.DTO
{
    public class OptionDto : BaseDto
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
