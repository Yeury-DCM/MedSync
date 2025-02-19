
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.ViewModels.LapResults;
using MedSync.Core.Domain.Entities;

namespace MedSync.Core.Application.ViewModels.LabTests
{
    public class LabTestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AppoimentId { get; set; } 
        public ICollection<LabResultViewModel>? LabResults { get; set; }
        public AppoimentViewModel? Appoiment { get; set; }
    }
}
