using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedSync.Presentation.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDoctorOfficeService _officeService;


        public UserController(IUserService userService, IDoctorOfficeService officeService)
        {
            _userService = userService;
            _officeService = officeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            UserViewModel userVm = await _userService.Login(loginViewModel);

            if (userVm != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userVm);
                return RedirectToRoute(new { controller = "Home", Action = "Index" });
            }
            else
            {
                ModelState.AddModelError("LoginError", "Datos de acceso incorrectos");
            }

            return View(loginViewModel);

        }

        public IActionResult Register()
        {
            ViewBag.UserTypes = Enum.GetValues(typeof(UserType))
                          .Cast<UserType>()
                          .Select(e => new SelectListItem
                          {
                              Value = e.ToString(),
                              Text = e.ToString()
                          })
                          .ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel saveUserViewModel)
        {


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

                return View(saveUserViewModel);
            }

            await _userService.Add(saveUserViewModel);
            return RedirectToRoute(new {controller = "User", action = "Index"});
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }
    }
}
