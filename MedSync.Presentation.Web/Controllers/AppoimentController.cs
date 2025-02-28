using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Domain.Entities;
using MedSync.Presentation.Web.Middelware;
namespace MedSync.Presentation.Web.Controllers
{
    public class AppoimentController : Controller
    {
        private readonly IAppoimentService _appoimentService;
        private readonly ILabTestService _labTestService;
        private readonly ILabResultService _labResultService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ValidateUserSession _validateUserSession;
        private readonly UserViewModel userViewModel;



        public AppoimentController(IAppoimentService userService, IHttpContextAccessor contextAccessor, IDoctorService doctorService, IPatientService patientService, ILabTestService labTestService, ILabResultService labResultService, ValidateUserSession validateUserSession)
        {
            _appoimentService = userService;
            _httpContext = contextAccessor;
            _doctorService = doctorService;
            _patientService = patientService;
            _labTestService = labTestService;
            _labResultService = labResultService;
            _validateUserSession = validateUserSession;
            userViewModel = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;
        }

        public async Task<IActionResult> Index()

        {
            if(!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            return View(await _appoimentService.GetAllByDoctorOfficeAsync(userViewModel.DoctorOfficeId));
        }

        public async Task <IActionResult> Add()
        {

            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            ViewBag.Doctors = await _doctorService.GetAllByDoctorOfficeAsync(userViewModel.DoctorOfficeId);
            ViewBag.Patients = await _patientService.GetAllByDoctorOfficeAsync(userViewModel.DoctorOfficeId);

            return View("SaveAppoiment");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveAppoimentViewModel saveAppoiment)
        {

            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            ModelState.Remove("DoctorOfficeId");
            ModelState.Remove("LabTests");
            ModelState.Remove("LabTestIds");
            ModelState.Remove("Id");
            

            if (!ModelState.IsValid)
            {
                ViewBag.Doctors = await _doctorService.GetAllByDoctorOfficeAsync(userViewModel.DoctorOfficeId);
                ViewBag.Patients = await _patientService.GetAllByDoctorOfficeAsync(userViewModel.DoctorOfficeId);
                return View("saveAppoiment", saveAppoiment);
            }

            saveAppoiment.DoctorOfficeId = userViewModel.DoctorOfficeId;
            await _appoimentService.Add(saveAppoiment);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ConsultAppoiment(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            SaveAppoimentViewModel saveAppoimentViewModel = await _appoimentService.GetByIdSaveViewModel(id);
            int doctorOfficeId = userViewModel.DoctorOfficeId;
            ViewBag.LabTests = await _labTestService.GetAllByDoctorOfficeAsync(doctorOfficeId);

            return View(saveAppoimentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConsultAppoiment(SaveAppoimentViewModel saveAppoimentViewModel)
        {

            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            int doctorOfficeId = userViewModel.DoctorOfficeId;

            ModelState.Remove("LabTests");
            ModelState.Remove("Cause");
            if (!ModelState.IsValid)
            {
                ViewBag.LabTests = await _labTestService.GetAllByDoctorOfficeAsync(doctorOfficeId);
                return View("ConsultAppoiment", saveAppoimentViewModel);
            }

             
            await _appoimentService.ConsultAppoiment(saveAppoimentViewModel);


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ConsultResults(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            ViewBag.AppoimentId = id;
            return View(await _labResultService.GetAllByAppoimentId(id));
        }


        [HttpPost]
        public async Task<IActionResult> FinishAppoiment(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });


            }
            await _appoimentService.FinishAppoiment(id);
           return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Edit(SaveAppoimentViewModel saveAppoiment)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            if (!ModelState.IsValid)
            {

                return View("SaveAppoiment", saveAppoiment);
            }

            await _appoimentService.Update(saveAppoiment);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            AppoimentViewModel? appoimentViewModel = await _appoimentService.GetById(id);

            return View("DeleteAppoiment", appoimentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            await _appoimentService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SeeResults(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            return View(await _labResultService.GetAllByAppoimentId(id));
        }
    }
}
