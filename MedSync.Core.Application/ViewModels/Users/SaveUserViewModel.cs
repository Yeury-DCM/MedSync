
using MedSync.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.Users
{
    public class SaveUserViewModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Appellido es requerido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "La Contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage ="La contraseñas deben coincidir")]
        [Required(ErrorMessage = "La Contraseña es requerido")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El tipo de usuario es querido")]
        [DataType(DataType.Text)]
        public UserType UserType { get; set; }
    }
}
