using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class Doctor : IdentifiablePerson
    {
        public string Email { get; set; }

        public int DoctorOfficeId {  get; set; }

        //Navegation Property
        public DoctorOffice DoctorOffice { get; set; }
        public ICollection<Appoiment> Appoiments{ get; set; }

    }
}
