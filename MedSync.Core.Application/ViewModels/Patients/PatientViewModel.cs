

using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.ViewModels.DoctorOffices;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.ViewModels.Patients
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string Adress { get; set; }
        public bool IsSmoker { get; set; }
        public bool HasAlergies { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }

        public DoctorOfficeViewModel DoctorOffice { get; set; }
        public ICollection<AppoimentViewModel> Appoiments { get; set;}

        public int DoctorOfficeId { get; set; } //FK
    }
}
