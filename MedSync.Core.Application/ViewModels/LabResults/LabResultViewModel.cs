
using MedSync.Core.Application.ViewModels.LabTests;
using MedSync.Core.Application.ViewModels.Patients;
using MedSync.Core.Domain.Entities;
using MedSync.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.LabResult
{
    public class LabResultViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
        public int LabTestId { get; set; }
        public PatientViewModel Patient { get; set; }
        public LabTestViewModel LabTest { get; set; }
        public Status Status { get; set; }

    }
}
