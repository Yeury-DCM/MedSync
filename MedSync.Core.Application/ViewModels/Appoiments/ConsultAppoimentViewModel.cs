using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSync.Core.Application.ViewModels.Appoiments
{
    public class ConsultAppoimentViewModel
    {
        public int Id { get; set; }

        public int PatientId {  get; set; }
        public int DoctorOfficeId { get; set; }
        public int DoctorId { get; set; }
        public List<int> LabTestsIds { get; set; }
    }
}
