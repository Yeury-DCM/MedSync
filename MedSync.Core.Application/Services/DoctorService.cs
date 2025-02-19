using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Services
{
    public class DoctorService : GenericService<DoctorViewModel, SaveDoctorViewModel, Doctor>, IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
