using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<UserViewModel, SaveUserViewModel, User>
    {
    }
}
