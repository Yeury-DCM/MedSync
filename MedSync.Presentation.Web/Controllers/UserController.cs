using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Presentation.Web.Middelware;
namespace MedSync.Presentation.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ValidateUserSession _validateUserSession;


        public UserController(IUserService userService, IHttpContextAccessor contextAccessor, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _httpContext = contextAccessor;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()

        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            UserViewModel userLogedIn = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;

            return View(await _userService.GetAllByDoctorOfficeAsync(userLogedIn.DoctorOfficeId));
        }

        public IActionResult Add()
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            ViewBag.UserTypes = Enum.GetValues(typeof(UserType))
                          .Cast<UserType>()
                          .Select(e => new SelectListItem
                          {
                              Value = e.ToString(),
                              Text = e.ToString()
                          })
                          .ToList();

            return View("SaveUser");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveUserViewModel saveUserViewModel)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            ModelState.Remove("DoctorOfficeName");
            if(!ModelState.IsValid)
            {
                ViewBag.UserTypes = Enum.GetValues(typeof(UserType))
                          .Cast<UserType>()
                          .Select(e => new SelectListItem
                          {
                              Value = e.ToString(),
                              Text = e.ToString()
                          })
                          .ToList();
                return View("SaveUser", saveUserViewModel);
            }

            await _userService.Add(saveUserViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            SaveUserViewModel saveUserViewModel = await _userService.GetByIdSaveViewModel(id);

            ViewBag.UserTypes = Enum.GetValues(typeof(UserType))
                          .Cast<UserType>()
                          .Select(e => new SelectListItem
                          {
                              Value = e.ToString(),
                              Text = e.ToString()
                          })
                          .ToList();


            return View("SaveUser", saveUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveUserViewModel saveUserViewModel)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");
            ModelState.Remove("DoctorOfficeName");


            if (!ModelState.IsValid)
            {
                ViewBag.UserTypes = Enum.GetValues(typeof(UserType))
                          .Cast<UserType>()
                          .Select(e => new SelectListItem
                          {
                              Value = e.ToString(),
                              Text = e.ToString()
                          })
                          .ToList();

                return View("SaveUser", saveUserViewModel);
            }

            await _userService.Update(saveUserViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            UserViewModel? userViewModel = await _userService.GetById(id);

            return View("DeleteUser", userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            await _userService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
