

using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedSync.Infraestructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : base(context, logger) 
        {
            _context = context;
            _logger = logger;
        }

        public override Task<User> AddAsync(User entity)
        {
            entity.Password = PasswordEncryption.ComputeShad256Hash(entity.Password);
            return base.AddAsync(entity);
        }

        public async Task <User> LoginAsync(LoginViewModel viewModel)
        {
            string encryptedPassword = PasswordEncryption.ComputeShad256Hash(viewModel.Password);

            User? user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Username == viewModel.UserName && u.Password == encryptedPassword);

            return user;
        }
    }
}
