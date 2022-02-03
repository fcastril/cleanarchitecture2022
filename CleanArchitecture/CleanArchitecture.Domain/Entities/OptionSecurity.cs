using CleanArchitecture.Domain.Common;
namespace CleanArchitecture.Domain.Entities
{
    public class OptionSecurity : BaseEntity
    {
        public Guid OptionId { get; set; }
        public virtual Option? Option { get; set; }
        public Guid ProfileId { get; set; }
        public virtual Profile? Profile { get; set; }

        public bool IsAccess { get; set; }
        public bool IsCreate { get; set; }
        public bool IsRead { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsExport { get; set; }  
        public bool IsCancel { get; set; }
        public bool IsPrint { get; set; }


    }
}
