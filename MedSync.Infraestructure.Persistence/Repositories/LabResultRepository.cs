

using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{   
    public class LabResultRepository : GenericRepository<LabResult>, ILabResultRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<LabResultRepository> _logger;

        public LabResultRepository(ApplicationDbContext context, ILogger<LabResultRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
        
    }
}
