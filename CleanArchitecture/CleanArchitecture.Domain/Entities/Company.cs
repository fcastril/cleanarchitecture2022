namespace CleanArchitecture.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public ICollection<UserCompanyProfile>? UserCompanyProfiles { get; set; }
        public ICollection<Profile>? Profiles { get; set; }
    }
}
