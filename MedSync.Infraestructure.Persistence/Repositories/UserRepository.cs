

using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;
using MedSync.Infraestructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

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

        public override async Task<bool> UpdateAsync(User entity)
        {

            var userToUpdate = await _context.Set<User>().FindAsync(entity.Id);

            if (userToUpdate == null)
            {
                return false;
            }

            userToUpdate.Name = entity.Name;
            userToUpdate.Username = entity.Username;
            userToUpdate.Email = entity.Email;
            userToUpdate.LastName = entity.LastName;
            userToUpdate.CreatedOn = entity.CreatedOn;
            userToUpdate.CreatedBy = entity.CreatedBy;
            userToUpdate.LastModified = entity.LastModified;
            userToUpdate.LastModifiedBy = entity.CreatedBy;
            userToUpdate.CreatedOn = entity.CreatedOn;
            userToUpdate.UserType = entity.UserType;


            if (!entity.Password.IsNullOrEmpty())
            {
                userToUpdate.Password = PasswordEncryption.ComputeShad256Hash(entity.Password);
            }


            _context.Update(userToUpdate);

            await _context.SaveChangesAsync();

            return true;  
        }


        public Task<IEnumerable<Appoiment>> GetByDoctorOfficeAsync(int doctorOfficeId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginAsync(LoginViewModel viewModel)
        {
            string encryptedPassword = PasswordEncryption.ComputeShad256Hash(viewModel.Password);

            User? user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Username == viewModel.UserName && u.Password == encryptedPassword);

            return user;
        }
    }
}
