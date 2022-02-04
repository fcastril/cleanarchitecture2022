
using CleanArchitecture.Domain.Common;
namespace CleanArchitecture.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            UserCompanyProfiles = new HashSet<UserCompanyProfile>();
            ProfilesCreated = new HashSet<Profile>();
            ProfilesUpdated = new HashSet<Profile>();
        }
        public string Login { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public virtual ICollection<UserCompanyProfile>? UserCompanyProfiles { get; set; }

        public virtual ICollection<Profile>? ProfilesCreated { get; set; }
        public virtual ICollection<Profile>? ProfilesUpdated { get; set; }

    }
}
