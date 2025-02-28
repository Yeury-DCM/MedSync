using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.ViewModels.LabResult;
using MedSync.Presentation.Web.Middelware;
namespace MedSync.Presentation.Web.Controllers
{
    public class LabResultController : Controller
    {
        private readonly ILabResultService _labResultService;
        private readonly IPatientService _patientService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ValidateUserSession _validateUserSession;
        


        public LabResultController(IAppoimentService userService, IHttpContextAccessor contextAccessor, ILabResultService labResultService, IPatientService patientService, ValidateUserSession validateUserSession)
        {
           
            _httpContext = contextAccessor;
            _labResultService = labResultService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index(string IdentificationNumber)

        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            UserViewModel userLogedIn = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;
            var labResultViewModels = await _labResultService.GetAllByDoctorOfficeAsync(userLogedIn.DoctorOfficeId);

            if (!string.IsNullOrWhiteSpace(IdentificationNumber))
            {
                return View(await _labResultService.GetAllByIdentificationNumber(labResultViewModels, IdentificationNumber));
            }

           

            return View(await _labResultService.GetAllByDoctorOfficeAsync(userLogedIn.DoctorOfficeId));
        }


        public async Task<IActionResult> ReportResult(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            SaveLabResultViewModel saveLabResultViewModel = await _labResultService.GetByIdSaveViewModel(id);
            return View(saveLabResultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ReportResult(SaveLabResultViewModel saveLabResultViewModel)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            await _labResultService.ReportResult(saveLabResultViewModel);
            return RedirectToAction("Index");
        }
    }
}
