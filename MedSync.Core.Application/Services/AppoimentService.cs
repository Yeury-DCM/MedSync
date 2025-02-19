using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.Services
{
    public class AppoimentService : GenericService<AppoimentViewModel, SaveAppoimentViewModel, Appoiment>, IAppoimentService
    {
        private readonly IAppoimentRepository _repository;
        private readonly IMapper _mapper;

        public AppoimentService(IAppoimentRepository appoimentRepository, IMapper mapper) : base(appoimentRepository, mapper) 
        {
            _repository = appoimentRepository;
            _mapper = mapper;
        }
    }
}
