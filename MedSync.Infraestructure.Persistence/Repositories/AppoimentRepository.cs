
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class AppoimentRepository : GenericRepository<Appoiment>, IAppoimentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AppoimentRepository> _logger;
        public AppoimentRepository(ApplicationDbContext context, ILogger<AppoimentRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public override async Task<ICollection<Appoiment>> GetAllAsync()
        {

            return await _context.Set<Appoiment>()
                 .Include(a => a.Doctor)
                 .Include(a => a.Patient)
                 .Include(a => a.LabTests)
                 .ToListAsync();
        }

        public override async Task<Appoiment?> GetByIdAsync(int id)
        {
            return await _context.Set<Appoiment>()
                 .Include(a => a.Doctor)
                 .Include(a => a.Patient)
                 .Include(a => a.LabTests)
                 .FirstOrDefaultAsync(a => a.Id == id);


        }
    }


}
