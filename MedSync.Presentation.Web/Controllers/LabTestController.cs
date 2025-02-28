using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Core.Application.ViewModels.LabTests;
using MedSync.Presentation.Web.Middelware;
namespace MedSync.Presentation.Web.Controllers
{
    public class LabTestController : Controller
    {
        private readonly ILabTestService _labTestService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ValidateUserSession _validateUserSession;
        private readonly UserViewModel _userViewModel;


        public LabTestController(ILabTestService labTestService, IHttpContextAccessor contextAccessor, ValidateUserSession validateUserSession)
        {
            _labTestService = labTestService;
            _httpContext = contextAccessor;
            _validateUserSession = validateUserSession;
            _userViewModel = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;
        }

        public async Task<IActionResult> Index()

        {
            if(!_validateUserSession.IsValidUser(UserType.Administrador))
            {
               return RedirectToRoute(new { controller = "Account", action = "Login" });
            }
         

            return View(await _labTestService.GetAllByDoctorOfficeAsync(_userViewModel.DoctorOfficeId));
        }

        public IActionResult Add()
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            return View("SaveLabTest");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveLabTestViewModel saveLabTestViewModel)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

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
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }
            SaveLabTestViewModel saveLabTestViewModel = await _labTestService.GetByIdSaveViewModel(id);

            return View("SaveLabTest", saveLabTestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveLabTestViewModel saveLabTestViewModel)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }
            if (!ModelState.IsValid)
            {

                return View("SaveLabTest", saveLabTestViewModel);
            }

            await _labTestService.Update(saveLabTestViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }
            LabTestViewModel? userViewModel = await _labTestService.GetById(id);

            return View("DeleteLabTest", userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }
            await _labTestService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
