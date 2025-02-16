using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class DoctorOffice :BaseEntity
    {
        public string Name { get; set; }

        //Navegation Properties

        public ICollection<Appoiment> Appoiments { get; set; }
        public  ICollection<Doctor> Doctors { get; set; }
        public ICollection<LabResult> LabResults { get; set; }
        public ICollection<LabTest> LabTests { get; set; }
        public ICollection<Patient> Patients { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
