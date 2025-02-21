

using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MedSync.Core.Application.Services
{
    public class AccountService : IAccountService
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public AccountService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Login(LoginViewModel viewModel)
        {

            User user = await _userRepository.LoginAsync(viewModel);

            if (user == null)
            {
                return null;
            }

            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }

    }
}
