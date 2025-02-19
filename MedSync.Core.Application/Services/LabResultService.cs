using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.LapResults;
using MedSync.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSync.Core.Application.Services
{
    public class LabResultService : GenericService<LabResultViewModel, SaveLabResultViewModel, LabResult>, ILabResultService
    {
        private readonly ILabResultRepository _repository;
        private readonly IMapper _mapper;

        public LabResultService(ILabResultRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}
