
using MedSync.Core.Application.Interfaces.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.LabTests
{
    public class SaveLabTestViewModel : IHaveId
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        public int DoctorOfficeId { get; set; } 
    }
}

