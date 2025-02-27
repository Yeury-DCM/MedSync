

using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
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

        public override async Task<ICollection<LabResult>> GetAllAsync()
        {

            return await _context.Set<LabResult>()
                 .Include(l => l.Patient)
                 .Include(l => l.LabTest)
                 .ToListAsync();
        }

        public override async Task<LabResult?> GetByIdAsync(int id)
        {
            return await _context.Set<LabResult>()
                 .Include(l => l.Patient)
                 .Include(l => l.LabTest)
                 .FirstOrDefaultAsync(l => l.Id == id);


        }
        public async Task<List<LabResult>> GetAllByAppoimentId(int appoimentId)
        {
            return await _context.Set<LabResult>()
                .Include(l => l.Patient) // Incluir la relación con Patient
                .Include(l => l.LabTest)
                .ThenInclude(lt => lt.Appoiments)// Incluir la relación con LabTest
                .Where(l => l.AppoimentId == appoimentId)
                .ToListAsync();
        }

        public async Task<List<LabResult>> GetAllByIdentificationNumber(string IdentificationNumber)
        {
            return await _context.Set<LabResult>()
          .Include(l => l.Patient) // Incluir la relación con Patient
          .Include(l => l.LabTest)
          .ThenInclude(lt => lt.Appoiments)// Incluir la relación con LabTest
          .Where(l => l.Patient.IdentificationNumber.Contains(IdentificationNumber))
          .ToListAsync();

        }
    }
    }
