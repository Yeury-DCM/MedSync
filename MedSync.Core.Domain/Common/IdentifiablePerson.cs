
namespace MedSync.Core.Domain.Common
{
    public class IdentifiablePerson : Person
    {
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }

    }
}
