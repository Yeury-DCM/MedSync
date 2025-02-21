
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Domain.Entities;
namespace MedSync.Core.Application.Interfaces.Services
{
    public interface IDoctorService : IGenericService<DoctorViewModel, SaveDoctorViewModel, Doctor>, IGetAllByDoctorOffice<DoctorViewModel>
    {
    }
}
