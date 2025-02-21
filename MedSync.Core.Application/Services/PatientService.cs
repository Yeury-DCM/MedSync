using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Patients;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MedSync.Core.Application.Services
{
    public class PatientService : GenericService<PatientViewModel, SavePatientViewModel, Patient>, IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _httpContext;

        public PatientService(IPatientRepository repository, IMapper mapper, IHttpContextAccessor httpContex) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _httpContext = httpContex;
        }

        public async Task<List<PatientViewModel>> GetAllByDoctorOfficeAsync(int doctorOfficeId)
        {
            List<Patient>patientsByDoctorOffice = ((List<Patient>)await _repository.GetAllAsync())
                                         .Where(p => p.DoctorOfficeId == doctorOfficeId).ToList();

            List<PatientViewModel> doctorsViewModels = _mapper.Map<List<PatientViewModel>>(patientsByDoctorOffice);

            return doctorsViewModels;
        }


        public override async Task<SavePatientViewModel> Add(SavePatientViewModel saveViewModel)
        {

            UserViewModel user = _httpContext.HttpContext.Session.Get<UserViewModel>("user")!;

            saveViewModel.DoctorOfficeId = user.DoctorOfficeId;


            return await base.Add(saveViewModel);
        }
    }
}
