

using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }
       
    }
}
