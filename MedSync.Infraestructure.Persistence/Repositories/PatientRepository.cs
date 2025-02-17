
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }
        
        
    }
}
