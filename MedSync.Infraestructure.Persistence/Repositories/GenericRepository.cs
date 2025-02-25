
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Common;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IAuditableEntity

    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;
        private ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _entities = context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<T> AddAsync(T entity)
        {

            try
            {
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();
             
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return entity;
        }

        public virtual async Task<bool> DeleteAsync( int id)
        {
            try
            {
                T? entity = await GetByIdAsync(id);
                entity!.IsActive = false;
                return await UpdateAsync(entity);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return false;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();   
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _entities.Update(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return false;
        }
    }
}
