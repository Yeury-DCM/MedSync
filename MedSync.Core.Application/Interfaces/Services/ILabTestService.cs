
using MedSync.Core.Application.ViewModels.LabTests;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Interfaces.Services
{
    public interface ILabTestService : IGenericService<LabTestViewModel,SaveLabTestViewModel, LabTest>
    {
    }
}
