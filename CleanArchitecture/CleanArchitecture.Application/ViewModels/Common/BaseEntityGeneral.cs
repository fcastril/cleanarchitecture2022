namespace CleanArchitecture.Application.ViewModels.Common
{
    public class BaseEntityGeneral : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Guid UserCreatedId { get; set; }
        public Guid UserUpdatedId { get; set; }
    }
}
