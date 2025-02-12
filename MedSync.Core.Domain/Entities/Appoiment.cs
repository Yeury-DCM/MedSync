
using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class Appoiment : BaseEntity
    {
        public int PatientId { get; set; } //Fk
        public int DoctorId { get; set; } //Fk
        public string Cause { get; set; }
        public string Status { get; set; } //Fk

        //Navegation Propertis
        public ICollection<LabTest> LabTests { get; set; }



    }
}
