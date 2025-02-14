using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class Doctor : IdentifiablePerson
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DoctorOfficeId { get; set; } //Fk

        //Navegation Properti
        public DoctorOffice DoctorOffice { get; set; }

    }
}
