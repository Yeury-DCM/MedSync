
namespace MedSync.Core.Domain.Common
{
    public interface IAuditableEntity
    {
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public int? LastModifiedBy { get; set; }
       
    }
}
