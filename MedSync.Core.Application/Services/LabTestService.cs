using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Application.ViewModels.LabTests;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Application.Helpers;

using MedSync.Core.Domain.Entities;

using Microsoft.AspNetCore.Http;

namespace MedSync.Core.Application.Services
{
    public class LabTestService : GenericService<LabTestViewModel, SaveLabTestViewModel, LabTest>, ILabTestService
    {
        private readonly ILabTestRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public LabTestService(ILabTestRepository repository, IMapper mapper, IHttpContextAccessor httpContext) : base(repository, mapper)
        {
            _repository = repository;   
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<LabTestViewModel>> GetAllByDoctorOfficeAsync(int doctorOfficeId)
        {
            List<LabTest> labTestsByDoctorOffice = ((List<LabTest>) await _repository.GetAllAsync())
                                            .Where(d => d.DoctorOfficeId == doctorOfficeId).ToList();

            List<LabTestViewModel> doctorsViewModels = _mapper.Map<List<LabTestViewModel>>(labTestsByDoctorOffice);

            return doctorsViewModels;
        }

        public override async Task<SaveLabTestViewModel> Add(SaveLabTestViewModel saveViewModel)
        {

            UserViewModel user = _httpContext.HttpContext.Session.Get<UserViewModel>("user")!;

            saveViewModel.DoctorOfficeId = user.DoctorOfficeId;


            return await base.Add(saveViewModel);
        }
    }
}
