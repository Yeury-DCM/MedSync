using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using MedSync.Presentation.Web.Middelware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedSync.Presentation.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly ValidateUserSession _validateUserSession;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel _userViewModel;


        public AccountController(IUserService userService, IDoctorOfficeService officeService, IAccountService accountService, ValidateUserSession validateUserSession, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _accountService = accountService;
            _validateUserSession = validateUserSession;
            _httpContextAccessor = contextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext!.Session.Get<UserViewModel>("user")!;
        }
        public IActionResult Login()
        {
            if (_validateUserSession.IsValidUser())
            {
                string controller = _userViewModel.UserType == UserType.Administrador ? "User" : "Patient";

                return RedirectToRoute(new { controller = controller, action = "Index" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            UserViewModel userVm = await _accountService.Login(loginViewModel);

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
            return RedirectToRoute(new {controller = "Account", action = "Login"});
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Account", action = "Login" });
        }
    }
}
