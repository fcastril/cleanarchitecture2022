using CleanArchitecture.Domain.Common;
namespace CleanArchitecture.Domain.Entities
{
    public class Profile : BaseGeneralEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public ICollection<UserCompanyProfile>? UserCompanyProfiles { get; set; }

        public ICollection<OptionSecurity>? OptionSecurities { get; set; }

    }
}
