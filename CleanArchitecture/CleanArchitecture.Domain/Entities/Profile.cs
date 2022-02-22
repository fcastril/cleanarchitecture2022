using CleanArchitecture.Domain.Common;
namespace CleanArchitecture.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public Profile()
        {
            UserCompanyProfiles = new HashSet<UserCompanyProfile>();
            OptionSecurities = new HashSet<OptionSecurity>();
        }

        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<UserCompanyProfile>? UserCompanyProfiles { get; set; }

        public virtual ICollection<OptionSecurity>? OptionSecurities { get; set; }

    }
}
