
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Ingrese el usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ingrese la contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
