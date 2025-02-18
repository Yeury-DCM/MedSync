

using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<DoctorRepository> _logger;

        public DoctorRepository(ApplicationDbContext dbContext, ILogger<DoctorRepository> logger) : base(dbContext, logger) 
        {
            _context = dbContext;
            _logger = logger;
        }
        
            
        
    }
}
