using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class Doctor : IdentifiablePerson
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public int OfficeId { get; set; } //Fk

        //Navegation Properti

    }
}
