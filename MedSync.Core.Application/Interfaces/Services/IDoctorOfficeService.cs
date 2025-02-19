using MedSync.Core.Application.ViewModels.DoctorOffices;
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Domain.Entities;


namespace MedSync.Core.Application.Interfaces.Services
{
    public interface IDoctorOfficeService : IGenericService<DoctorOfficeViewModel, SaveDoctorOfficeViewModel, DoctorOffice>
    {
    }
}
