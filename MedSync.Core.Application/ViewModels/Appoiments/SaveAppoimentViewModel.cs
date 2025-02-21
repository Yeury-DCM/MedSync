
using MedSync.Core.Application.Interfaces.ViewModels;
using MedSync.Core.Application.ViewModels.LabTests;
using MedSync.Core.Domain.Entities;
using MedSync.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.Appoiments
{
    public class SaveAppoimentViewModel : IHaveId
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "El motivo de la cita es requerido.")]
        public string Cause { get; set; }
        [Required(ErrorMessage = "El doctor es requerido.")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "El paciente es requerido.")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public Status Status { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "La hora es requerida")]
        public TimeSpan Time { get; set; }
        public int DoctorOfficeId { get; set; }
        
        public ICollection<LabTestViewModel> LabTests { get; set; }
    }
}
