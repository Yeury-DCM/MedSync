using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public async Task<List<AppoimentViewModel>> GetAllByDoctorOfficeAsync(int doctorOfficeId)
        {
            {
                List<Appoiment> appoimentsByDoctorOffice = ((List<Appoiment>)await _repository.GetFullAppoiments())
                                                 .Where(d => d.DoctorOfficeId == doctorOfficeId).ToList();

                List<AppoimentViewModel> appoimentsViewModel = _mapper.Map<List<AppoimentViewModel>>(appoimentsByDoctorOffice);

                return appoimentsViewModel;
            }
        }

        public async Task<List<AppoimentViewModel>> GetFullAppoiments()
        {
            List<Appoiment> fullAppoiments = (List<Appoiment>) await _repository.GetFullAppoiments();

            List<AppoimentViewModel> fullAppoimentsViewModel = _mapper.Map<List<AppoimentViewModel>>(fullAppoiments);

            return fullAppoimentsViewModel;

        }
    }
}

