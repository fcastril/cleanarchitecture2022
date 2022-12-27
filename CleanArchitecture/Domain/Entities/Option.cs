using Domain.Common;
namespace Domain.Entities
{
    public class Option : BaseEntity
    {
        public Option()
        {
            //OptionSecurities = new HashSet<OptionSecurity>();
        }


        public string? Code { get; set; }
        public string? Name { get; set; }
        //public virtual ICollection<OptionSecurity>? OptionSecurities { get; set; }

    }
}
