
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Application.ViewModels.LabTests;
using MedSync.Core.Application.ViewModels.Patients;
using MedSync.Core.Domain.Entities;
using MedSync.Core.Domain.Enums;

namespace MedSync.Core.Application.ViewModels.Appoiments
{
    public class AppoimentViewModel
    {
        public int Id { get; set; }
        public string Cause { get; set; }
        public Status Status { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public PatientViewModel Patient {  get; set; }
        public int PatientId { get; set; } //Fk
        public int DoctorId { get; set; } //Fk
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public List<LabTestViewModel> LabTests { get; set; }

    }
}
