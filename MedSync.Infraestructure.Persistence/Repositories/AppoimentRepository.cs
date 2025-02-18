
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class AppoimentRepository : GenericRepository<Appoiment>, IAppoimentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AppoimentRepository> _logger;
        public AppoimentRepository(ApplicationDbContext context, ILogger<AppoimentRepository> logger): base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
