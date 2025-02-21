using MedSync.Core.Application.Interfaces.ViewModels;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.Doctors
{
    public class SaveDoctorViewModel : IHaveId
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El Apellido es requerido")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "El correo es requerido")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El numero de telefono es requerido")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La cédula")]
        public string IdentificationNumber { get; set; }
        public string ImagePath { get; set; }

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "La imagen del doctor es requerida")]
        public IFormFile File { get; set; }

        public int DoctorOfficeId { get; set; }

    }
}
