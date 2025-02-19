using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.DoctorOffices;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Services
{
    public class DoctorOfficeService : GenericService<DoctorOfficeViewModel, SaveDoctorOfficeViewModel, DoctorOffice>, IDoctorOfficeService
    {
        private readonly IDoctorOfficeRepository _repository;
        private readonly IMapper _mapper;

        public DoctorOfficeService(IDoctorOfficeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
