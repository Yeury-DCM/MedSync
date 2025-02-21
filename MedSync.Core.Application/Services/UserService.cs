
using AutoMapper;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.DoctorOffices;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MedSync.Core.Application.Services
{
    public class UserService : GenericService<UserViewModel, SaveUserViewModel, User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDoctorOfficeService _officeSerivice;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        public UserService(IUserRepository repository, IMapper mapper, IDoctorOfficeService officeService, IHttpContextAccessor httpContext) : base(repository, mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
            _officeSerivice = officeService;
            _httpContext = httpContext;

        }

        public override async Task<SaveUserViewModel> Add(SaveUserViewModel saveViewModel)
        {
            if(saveViewModel.DoctorOfficeName != null)
            {
                SaveDoctorOfficeViewModel officeViewModel = new()
                {
                    Name = saveViewModel.DoctorOfficeName,

                };

                SaveDoctorOfficeViewModel office = await _officeSerivice.Add(officeViewModel);

                saveViewModel.DoctorOfficeId = office.Id;

                return await base.Add(saveViewModel);
            }

            UserViewModel user = _httpContext.HttpContext.Session.Get<UserViewModel>("user")!;

            saveViewModel.DoctorOfficeId = user.DoctorOfficeId;
            

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

        public async Task<List<UserViewModel>> GetAllByDoctorOfficeAsync(int doctorOfficeId)
        {
            List<User> usersByDoctorOffice =  ((List<User>) await _userRepository.GetAllAsync())
                                               .Where(u => u.DoctorOfficeId == doctorOfficeId).ToList();

            List<UserViewModel> usersViewModel = _mapper.Map<List<UserViewModel>>(usersByDoctorOffice);

            return usersViewModel;
        }

        public Enum GetUserTypes()
        {
            throw new NotImplementedException();
        }

    }   
}
