using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MedSync.Presentation.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContext;


        public UserController(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _httpContext = contextAccessor;
        }

        public async Task<IActionResult> Index()

        {
            UserViewModel userLogedIn = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;

            return View(await _userService.GetAllByDoctorOfficeAsync(userLogedIn.DoctorOfficeId));
        }

        public IActionResult Add()
        {
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
            UserViewModel? userViewModel = await _userService.GetById(id);

            return View("DeleteUser", userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _userService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
