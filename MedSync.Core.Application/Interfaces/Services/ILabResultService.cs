
using MedSync.Core.Application.ViewModels.LapResults;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Interfaces.Services
{
    public interface ILabResultService : IGenericService<LabResultViewModel, SaveLabResultViewModel, LabResult>, IGetAllByDoctorOffice<Appoiment>
    {

    }
}
