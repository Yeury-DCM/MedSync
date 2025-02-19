using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class LabTest : BaseEntity
    {
        public string Name { get; set; }
        public int? AppoimentId { get; set; } //Fl

        public int DoctorOfficeId { get; set; } //FK

        //Navegation Property
        public ICollection<LabResult> LabResults { get; set; }
        public DoctorOffice DoctorOffice { get; set; }
        public Appoiment? Appoiment { get; set; }
    }
}
