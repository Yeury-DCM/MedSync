
namespace MedSync.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
