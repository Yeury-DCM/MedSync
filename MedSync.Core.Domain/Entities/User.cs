using MedSync.Core.Domain.Common;

namespace MedSync.Core.Domain.Entities
{
    public class User : Person
    {
        public string Username { get; set; }
        public  string Email { get; set; }
        public string Password { get; set; }

        //FKs
       // public int RoleId { get; set; }
        public int OfficeId { get; set; }

        //Navegation Properties


    }
}
