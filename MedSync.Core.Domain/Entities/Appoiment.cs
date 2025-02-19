
using MedSync.Core.Domain.Common;
using MedSync.Core.Domain.Enums;

namespace MedSync.Core.Domain.Entities
{
    public class Appoiment : BaseEntity
    {
        public string Cause { get; set; }
        public Status Status { get; set; }
        public int PatientId { get; set; } //Fk
        public int DoctorId { get; set; } //Fk
        public int DoctorOfficeId { get; set; } //FK

        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        //Navegation Propertis
        public ICollection<LabTest> LabTests { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DoctorOffice DoctorOffice { get; set; } 

    }
}
