using MedSync.Core.Application.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSync.Core.Application.ViewModels.DoctorOffices
{
    public class SaveDoctorOfficeViewModel : IHaveId
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
    }
}
