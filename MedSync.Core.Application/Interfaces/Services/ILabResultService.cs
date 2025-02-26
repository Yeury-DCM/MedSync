
using MedSync.Core.Application.ViewModels.LabResult;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Interfaces.Services
{
    public interface ILabResultService : IGenericService<LabResultViewModel, SaveLabResultViewModel, LabResult>, IGetAllByDoctorOffice<LabResultViewModel>
    {
        Task ReportResult(SaveLabResultViewModel result);
        Task<List<LabResultViewModel>> GetAllByAppoimentId(int appoimentId);

    }
}
