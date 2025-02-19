
using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Services
{
    public class UserService : GenericService<UserViewModel, SaveUserViewModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }
    }
}
