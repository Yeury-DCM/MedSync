﻿
using System.ComponentModel.DataAnnotations;

namespace MedSync.Core.Application.ViewModels.Patients
{
    public class SavePatientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El apellido es requerido.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El número de telefono es requerido.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "La cédula es requerida")]
        public string IdentificationNumber { get; set; }
        [Required(ErrorMessage = "La dirección es requerida.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Indique si es fumador.")]
        public bool IsSmoker { get; set; }
        [Required(ErrorMessage = "Indique si tiene alergias.")]
        public bool HasAlergies { get; set; }
        public int DoctorOfficeId { get; set; } //FK

    }
}
