using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.LabTests;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Services
{
    public class LabTestService : GenericService<LabTestViewModel, SaveLabTestViewModel, LabTest>, ILabTestService
    {
        private readonly ILabTestRepository _repository;
        private readonly IMapper _mapper;

        public LabTestService(ILabTestRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;   
            _mapper = mapper;
        }
    }
}
