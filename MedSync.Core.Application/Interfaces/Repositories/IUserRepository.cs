
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> LoginAsync(LoginViewModel viewModel);
    }
}
