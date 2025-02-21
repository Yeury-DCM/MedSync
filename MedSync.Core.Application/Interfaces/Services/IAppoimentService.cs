
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Interfaces.Services
{
    public interface IAppoimentService : IGenericService<AppoimentViewModel,SaveAppoimentViewModel, Appoiment>, IGetAllByDoctorOffice<Appoiment>
    {
    }
}
