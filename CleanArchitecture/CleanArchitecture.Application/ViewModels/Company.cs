using CleanArchitecture.Application.ViewModels.Common;

namespace CleanArchitecture.Application.ViewModels
{
    public class Company: BaseEntityGeneral
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
