using MedSync.Core.Domain.Common;
using MedSync.Core.Domain.Enums;

namespace MedSync.Core.Domain.Entities
{
    public class User : Person
    {
        public string Username { get; set; }
        public  string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public int DoctorOfficeId {  get; set; }
   

        //Navegation Properties

        public DoctorOffice DoctorOffice { get; set; }

    }
}
