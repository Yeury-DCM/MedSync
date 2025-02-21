using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MedSync.Core.Application.Services
{
    public class DoctorService : GenericService<DoctorViewModel, SaveDoctorViewModel, Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public DoctorService(IDoctorRepository repository, IMapper mapper, IHttpContextAccessor httpContext) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContext = httpContext; 
        }

        public async Task<List<DoctorViewModel>> GetAllByDoctorOfficeAsync(int doctorOfficeId)
        {
            List<Doctor> doctorsByDoctorOffice = ((List<Doctor>) await _repository.GetAllAsync())
                                             .Where(d => d.DoctorOfficeId == doctorOfficeId).ToList();

            List<DoctorViewModel> doctorsViewModels = _mapper.Map<List<DoctorViewModel>>(doctorsByDoctorOffice);

            return doctorsViewModels;
        }

        public override async Task<SaveDoctorViewModel> Add(SaveDoctorViewModel saveViewModel)
        {
           
            UserViewModel user = _httpContext.HttpContext.Session.Get<UserViewModel>("user")!;

            saveViewModel.DoctorOfficeId = user.DoctorOfficeId;


            return await base.Add(saveViewModel);
        }
    }
}
