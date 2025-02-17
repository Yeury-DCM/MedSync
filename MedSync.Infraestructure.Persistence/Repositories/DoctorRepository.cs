

using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger) { }
        
            
        
    }
}
