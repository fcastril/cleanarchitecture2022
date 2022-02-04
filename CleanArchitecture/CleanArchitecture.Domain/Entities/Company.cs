using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            UserCompanyProfiles = new HashSet<UserCompanyProfile>();
            Profiles = new HashSet<Profile>();
        }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<UserCompanyProfile>? UserCompanyProfiles { get; set; }
        public virtual ICollection<Profile>? Profiles { get; set; }
    }
}
