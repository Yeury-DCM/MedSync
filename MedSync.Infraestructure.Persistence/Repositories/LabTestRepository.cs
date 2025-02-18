
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class LabTestRepository : GenericRepository<LabTest>, ILabTestRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<LabTestRepository> _logger;

        public LabTestRepository(ApplicationDbContext context, ILogger<LabTestRepository> logger) : base(context, logger) 
        {
            _context = context;
            _logger = logger;
        }
        
    }
}
