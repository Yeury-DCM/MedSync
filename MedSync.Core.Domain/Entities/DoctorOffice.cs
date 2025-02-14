using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class DoctorOffice :BaseEntity
    {
        public string Name { get; set; }

        //Navegation Properties

        ICollection<Appoiment> Appoiments { get; set; }
        ICollection<Doctor> Doctors { get; set; }
        ICollection<LabResult> LabResults { get; set; }
        ICollection<LabTest> LabTests { get; set; }
        ICollection<Patient> Patients { get; set; }
        ICollection<User> Users { get; set; }

    }
}
