namespace CleanArchitecture.Domain.Entities
{
    public class Option : BaseEntity
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public ICollection<OptionSecurity>? OptionSecurities { get; set; }

    }
}
