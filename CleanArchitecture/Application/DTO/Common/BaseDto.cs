namespace Application.DTO.Common
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset UpdatedDateTime { get; set; }
        public bool State { get; set; }
    }
}
