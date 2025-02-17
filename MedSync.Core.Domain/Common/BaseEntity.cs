namespace MedSync.Core.Domain.Common
{
    public class BaseEntity : IAuditableEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; } 
        public DateTime? LastModified { get; set; } =  DateTime.Now;
        public int? LastModifiedBy { get; set; } 

    }
}
