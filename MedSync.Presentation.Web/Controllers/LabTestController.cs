using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Core.Application.ViewModels.LabTests;
namespace MedSync.Presentation.Web.Controllers
{
    public class LabTestController : Controller
    {
        private readonly ILabTestService _labTestService;
        private readonly IHttpContextAccessor _httpContext;


        public LabTestController(ILabTestService labTestService, IHttpContextAccessor contextAccessor)
        {
            _labTestService = labTestService;
            _httpContext = contextAccessor;
        }

        public async Task<IActionResult> Index()

        {
            UserViewModel userLogedIn = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;

            return View(await _labTestService.GetAllByDoctorOfficeAsync(userLogedIn.DoctorOfficeId));
        }

        public IActionResult Add()
        {

            return View("SaveLabTest");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveLabTestViewModel saveLabTestViewModel)
        {
            ModelState.Remove("DoctorOfficeId");
            if(!ModelState.IsValid)
            {  
                return View("SaveLabTest", saveLabTestViewModel);
            }

            await _labTestService.Add(saveLabTestViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            SaveLabTestViewModel saveLabTestViewModel = await _labTestService.GetByIdSaveViewModel(id);

            return View("SaveLabTest", saveLabTestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveLabTestViewModel saveLabTestViewModel)
        {
          
            if (!ModelState.IsValid)
            {

                return View("SaveLabTest", saveLabTestViewModel);
            }

            await _labTestService.Update(saveLabTestViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            LabTestViewModel? userViewModel = await _labTestService.GetById(id);

            return View("DeleteLabTest", userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _labTestService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
