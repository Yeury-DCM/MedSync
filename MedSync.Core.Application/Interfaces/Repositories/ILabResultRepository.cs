using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Interfaces.Repositories
{
    public interface ILabResultRepository : IGenericRepository<LabResult>
    {
        Task<List<LabResult>> GetAllByAppoimentId(int AppoimentId);
    }
}
