namespace CleanArchitecture.Domain.Entities
{
    public class UserCompanyProfile : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
        public Guid CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public Guid ProfileId { get; set; }
        public virtual Profile? Profile { get; set; }

    }
}
