
using MedSync.Core.Domain.Common;

namespace MedSync.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class, IAuditableEntity
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

    }
}
