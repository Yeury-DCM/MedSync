﻿
using MedSync.Core.Application.Interfaces.ViewModels;
using MedSync.Core.Domain.Entities;
using MedSync.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.LabResult
{
    public class SaveLabResultViewModel : IHaveId
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La hora es requerida")]
        public int PatientId { get; set; }
        public int LabTestId { get; set; }
        public int DoctorOfficeId { get; set; }
        public int AppoimentId { get; set; }
        public Status Status { get; set; }

    }
}
