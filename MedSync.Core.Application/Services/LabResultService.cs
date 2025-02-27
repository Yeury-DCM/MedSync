using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.ViewModels.LabResult;
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

        public async Task<List<LabResultViewModel>> GetAllByDoctorOfficeAsync(int doctorOfficeId)
        {
            List<LabResult> labResultsByDoctorOffice = ((List<LabResult>) await _repository.GetAllAsync())
                                             .Where(d => d.DoctorOfficeId == doctorOfficeId).ToList();

            List<LabResultViewModel> labResultViewModels = _mapper.Map<List<LabResultViewModel>>(labResultsByDoctorOffice);

            return labResultViewModels;
        }

        public async Task ReportResult(SaveLabResultViewModel result)
        {
           
            result.Status = Domain.Enums.Status.Completed;
            await base.Update(result);
        }

        public async Task<List<LabResultViewModel>> GetAllByAppoimentId(int appoimentId)
        {

            List<LabResult> labResultsByAppoimentId= await _repository.GetAllByAppoimentId(appoimentId);

             
            List<LabResultViewModel> labResultViewModels = _mapper.Map<List<LabResultViewModel>>(labResultsByAppoimentId);

            return labResultViewModels;
        }

        public  async Task<List<LabResultViewModel>> GetAllByIdentificationNumber(List<LabResultViewModel> labResultsViewModels, string identificationNumber)
        {
            List<LabResultViewModel> labResultsFiltered = labResultsViewModels.Where(lr => lr.Patient.IdentificationNumber.Contains(identificationNumber)).ToList();

            return labResultsFiltered;
        }
    }
}
