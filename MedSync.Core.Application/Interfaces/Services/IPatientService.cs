
using MedSync.Core.Application.ViewModels.Patients;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Interfaces.Services
{
    public interface IPatientService : IGenericService<PatientViewModel, SavePatientViewModel, Patient>, IGetAllByDoctorOffice<Patient>
    {
    }
}
