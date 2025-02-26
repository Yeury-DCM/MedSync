using MedSync.Core.Domain.Common;
using MedSync.Core.Domain.Enums;

namespace MedSync.Core.Domain.Entities
{
    public class LabResult : BaseEntity
    {
        public string? Description { get; set; }
        public int PatientId { get; set; } //FK
        public Status Status { get; set; }
        public int? LabTestId { get; set; } 
        public int DoctorOfficeId { get; set; }

        //Navegation properties
        public Patient Patient { get; set; }
        public LabTest  LabTest  { get; set; }
        public DoctorOffice DoctorOffice { get; set; }

    }
}
