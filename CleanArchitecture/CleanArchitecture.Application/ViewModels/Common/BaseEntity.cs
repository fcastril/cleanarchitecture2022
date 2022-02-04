namespace CleanArchitecture.Application.ViewModels.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool State { get; set; }
    }
}
