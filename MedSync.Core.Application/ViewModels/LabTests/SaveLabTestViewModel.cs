
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.LabTests
{
    public class SaveLabTestViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        public int DoctorOfficeId { get; set; } 
    }
}

