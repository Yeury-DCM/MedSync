
using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.DoctorOffices;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Services
{
    public class UserService : GenericService<UserViewModel, SaveUserViewModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDoctorOfficeService _officeSerivice;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper, IDoctorOfficeService officeService) : base(repository, mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
            _officeSerivice = officeService;
        }

        public override async Task<User> Add(SaveUserViewModel saveViewModel)
        {
            SaveDoctorOfficeViewModel officeViewModel = new()
            {
                Name = saveViewModel.DoctorOfficeName,

            };

            DoctorOffice office =await _officeSerivice.Add(officeViewModel);

            saveViewModel.DoctorOfficeId = office.Id;
            

            return await base.Add(saveViewModel);
        }

        public async Task<UserViewModel> Login(LoginViewModel viewModel)
        {
            User user = await _userRepository.LoginAsync(viewModel);

            if(user == null)
            {
                return null;
            }

            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }
    }   
}
