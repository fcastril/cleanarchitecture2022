namespace CleanArchitecture.Application.DTO.Common
{
    public class BaseGeneralDto : BaseDto
    {
        public Guid CompanyId { get; set; }
        public Guid UserCreatedId { get; set; }
        public Guid UserUpdatedId { get; set; }
    }
}
