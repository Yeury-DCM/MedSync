using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Domain.Enums;
using MedSync.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MedSync.Core.Application.ViewModels.LabResult;

namespace MedSync.Core.Application.Services
{
    public class AppoimentService : GenericService<AppoimentViewModel, SaveAppoimentViewModel, Appoiment>, IAppoimentService
    {
        private readonly IAppoimentRepository _repository;
        private readonly ILabTestService _labtestService;
        private readonly ILabTestRepository _labTestRepository;
        private readonly ILabResultService _labResultService;
        private readonly IMapper _mapper;

        public AppoimentService(IAppoimentRepository appoimentRepository, IMapper mapper, ILabTestService labTestService, ILabTestRepository labTestRepository, ILabResultService labResultService) : base(appoimentRepository, mapper)
        {
            _repository = appoimentRepository;
            _mapper = mapper;
            _labtestService = labTestService;
            _labTestRepository = labTestRepository;
            _labResultService = labResultService;
        }

        public async Task ConsultAppoiment(SaveAppoimentViewModel saveAppoimentViewModel)
        {
            Appoiment? appoiment = await _repository.GetByIdAsync(saveAppoimentViewModel.Id);

          
            foreach (int labTestId in saveAppoimentViewModel.LabTestIds)
            {
                appoiment?.LabTests.Add(await _labTestRepository.GetByIdAsync(labTestId));

                SaveLabResultViewModel saveLabResultViewModel = new()
                {
                    LabTestId = labTestId,
                    PatientId = saveAppoimentViewModel.PatientId,
                    Status = Status.Pending,
                    DoctorOfficeId = saveAppoimentViewModel.DoctorOfficeId,
                    AppoimentId = saveAppoimentViewModel.Id

                };

                await _labResultService.Add(saveLabResultViewModel);

            }

            appoiment!.Status = Status.PendigResult;

            await _repository.UpdateAsync(appoiment);
        }

        public async Task<List<AppoimentViewModel>> GetAllByDoctorOfficeAsync(int doctorOfficeId)
        {

            List<Appoiment> appoimentsByDoctorOffice = ((List<Appoiment>)await _repository.GetAllAsync())
                                             .Where(d => d.DoctorOfficeId == doctorOfficeId).ToList();

            List<AppoimentViewModel> appoimentsViewModel = _mapper.Map<List<AppoimentViewModel>>(appoimentsByDoctorOffice);

            return appoimentsViewModel;

        }

        public async Task<List<AppoimentViewModel>> GetFullAppoiments()
        {
            List<Appoiment> fullAppoiments = (List<Appoiment>)await _repository.GetAllAsync();

            List<AppoimentViewModel> fullAppoimentsViewModel = _mapper.Map<List<AppoimentViewModel>>(fullAppoiments);

            return fullAppoimentsViewModel;

        }


    }
}

