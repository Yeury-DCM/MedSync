using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Patients;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Services
{
    public class PatientService : GenericService<PatientViewModel, SavePatientViewModel, Patient>, IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<List<Patient>> GetAllByDoctorOfficeAsync(int doctorOfficeId)
        {
            throw new NotImplementedException();
        }
    }
}
