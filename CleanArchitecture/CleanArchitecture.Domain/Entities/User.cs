namespace CleanArchitecture.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<UserCompanyProfile>? UserCompanyProfiles { get; set; }

        public ICollection<Profile>? ProfilesCreated { get; set; }
        public ICollection<Profile>? ProfilesUpdated{ get; set; }

    }
}
