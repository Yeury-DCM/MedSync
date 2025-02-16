using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class LabResult : BaseEntity
    {
        public string Description { get; set; }
        public int PatientId { get; set; } //FK
        public string Status { get; set; } //FK

        //Navegation properties
        public Patient Patient { get; set; }
        public LabTest LabTest { get; set; }

        
 
    }
}
