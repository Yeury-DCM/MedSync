
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<PatientRepository> _logger;

        public PatientRepository(ApplicationDbContext context, ILogger<PatientRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
        
        
    }
}
