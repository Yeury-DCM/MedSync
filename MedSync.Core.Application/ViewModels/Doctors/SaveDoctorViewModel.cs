using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.Doctors
{
    public class SaveDoctorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string ImagePath { get; set; }
        public int DoctorOfficeId { get; set; }

    }
}
