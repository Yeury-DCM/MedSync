using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.ViewModels.LabResult;
namespace MedSync.Presentation.Web.Controllers
{
    public class LabResultController : Controller
    {
        private readonly ILabResultService _labResultService;
        private readonly IPatientService _patientService;
        private readonly IHttpContextAccessor _httpContext;
        


        public LabResultController(IAppoimentService userService, IHttpContextAccessor contextAccessor, ILabResultService labResultService, IPatientService patientService)
        {
           
            _httpContext = contextAccessor;
            _labResultService = labResultService;
        }

        public async Task<IActionResult> Index()

        {
            UserViewModel userLogedIn = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;

            return View(await _labResultService.GetAllByDoctorOfficeAsync(userLogedIn.DoctorOfficeId));
        }


        public async Task<IActionResult> ReportResult(int id)
        {
            SaveLabResultViewModel saveLabResultViewModel = await _labResultService.GetByIdSaveViewModel(id);
            return View(saveLabResultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ReportResult(SaveLabResultViewModel saveLabResultViewModel)
        {

            await _labResultService.ReportResult(saveLabResultViewModel);
            return RedirectToAction("Index");
        }
    }
}
