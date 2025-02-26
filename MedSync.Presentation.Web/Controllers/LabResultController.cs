using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.ViewModels.LapResults;
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

        public async Task <IActionResult> Add()
        {

            UserViewModel user = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;

            return View("SaveLabResult");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveLabResultViewModel saveLabResult)
        {
            ModelState.Remove("DoctorOfficeId");
            ModelState.Remove("LabTests");
            ModelState.Remove("Id");


            if (!ModelState.IsValid)
            {                    
                return View("saveLabResult", _labResultService);
            }

          //  saveLabResult = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!.DoctorOfficeId;
            await _labResultService.Add(saveLabResult);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

           SaveLabResultViewModel saveLabResultViewModel = await _labResultService.GetByIdSaveViewModel(id);

            return View("SaveLabREsult", saveLabResultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveLabResultViewModel saveLabResult)
        {
      
            if (!ModelState.IsValid)
            {

                return View("SaveLabResult", saveLabResult);
            }

            await _labResultService.Update(saveLabResult);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            LabResultViewModel? labResultViewModel = await _labResultService.GetById(id);

            return View("DeleteAppoiment", labResultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _labResultService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
