using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class LabTest : BaseEntity
    {
        public string Name { get; set; }
        public int AppoimentId { get; set; } //FK
        public int DoctorOfficeId { get; set; } //FK

        //Navegation Property
        public LabResult LabResult { get; set; }
        public DoctorOffice DoctorOffice { get; set; }
    }
}
