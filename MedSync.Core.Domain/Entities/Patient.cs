using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class Patient : IdentifiablePerson
    {   
        public string Adress { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasAlergies { get; set; }
        public int DoctorOfficeId { get; set; } //FK

        public DateTime BirthDate { get; set; }

        //Navegation Property
        public DoctorOffice DoctorOffice { get; set; }

        public ICollection<Appoiment> Appoiments { get; set;}
    }
}
