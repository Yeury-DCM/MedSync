
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class DoctorOfficeRepository : GenericRepository<DoctorOffice>, IDoctorOfficeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DoctorOfficeRepository> _logger;
        public DoctorOfficeRepository(ApplicationDbContext context, ILogger<DoctorOfficeRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
