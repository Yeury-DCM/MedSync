
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.ViewModels.Doctors
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string ImagePath { get; set; }
        public ICollection<AppoimentViewModel> Appoiments { get; set; }

    }
}
