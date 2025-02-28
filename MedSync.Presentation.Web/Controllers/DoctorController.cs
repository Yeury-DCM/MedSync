using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.DoctorOffices;
using MedSync.Core.Application.ViewModels.Doctors;
using MedSync.Core.Application.Services;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Presentation.Web.Middelware;
using MedSync.Core.Application.ViewModels.Patients;

namespace MedSync.Presentation.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ValidateUserSession _validateUserSession;
        private readonly UserViewModel _userViewModel;

        public DoctorController(IDoctorService doctorService, IHttpContextAccessor httpContext, ValidateUserSession validateUserSession)
        {
            _doctorService = doctorService;
            _httpContext = httpContext;
            _validateUserSession = validateUserSession;
            _userViewModel = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;

        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            return View(await _doctorService.GetAllByDoctorOfficeAsync(_userViewModel.DoctorOfficeId));
        }

        public async Task<IActionResult> Detail(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            DoctorViewModel? doctor = await _doctorService.GetById(id);
            return View(doctor);
        }

        public IActionResult Add()
        {
            return View("SaveDoctor");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveDoctorViewModel saveDoctorViewModel)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            ModelState.Remove("ImagePath");
            ModelState.Remove("DoctorOfficeId");
            ModelState.Remove("Id");

            if (!ModelState.IsValid)
            {
                return View("SaveDoctor", saveDoctorViewModel);
            }

            SaveDoctorViewModel doctorViewModel = await _doctorService.Add(saveDoctorViewModel);

            if (doctorViewModel != null && doctorViewModel.Id != 0)
            {
                doctorViewModel.ImagePath = (UploadFile(saveDoctorViewModel.File, doctorViewModel.Id));
                await _doctorService.Update(doctorViewModel);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            SaveDoctorViewModel saveUserViewModel = await _doctorService.GetByIdSaveViewModel(id);

            return View("SaveDoctor", saveUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveDoctorViewModel saveDoctorViewModel)
        {

            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            ModelState.Remove("File");
            ModelState.Remove("ImagePath");



            if (!ModelState.IsValid)
            {

                return View("SaveDoctor", saveDoctorViewModel);
            }

            SaveDoctorViewModel savedDoctorViewModel = await _doctorService.GetByIdSaveViewModel(saveDoctorViewModel.Id);

            saveDoctorViewModel.ImagePath = UploadFile(saveDoctorViewModel.File, saveDoctorViewModel.Id, true, savedDoctorViewModel.ImagePath);
            //  saveDoctorViewModel.

            await _doctorService.Update(saveDoctorViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            DoctorViewModel? doctorViewModel = await _doctorService.GetById(id);

            return View("DeleteDoctor", doctorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Administrador))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            await _doctorService.Delete(id);

            //Get Directory Path
            string basePath = $"/images/Doctors/{id}";
            string path = $"{Directory.GetCurrentDirectory()}/wwwroot{basePath}";

            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }

                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete();
                }

                Directory.Delete(path, true);

            }
            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string imagePath = "")
        {


            if (isEditMode && file == null)
            {
                return imagePath;
            }

            //Get Directory Path
            string basePath = $"/images/Doctors/{id}";
            string path = $"{Directory.GetCurrentDirectory()}/wwwroot{basePath}";

            //Create folder if no exists

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //Get File Path

            Guid guid = Guid.NewGuid();
            var fileInfo = new FileInfo(file.FileName);
            string fileName = $"{guid}_{fileInfo.Name}";


            string fileNameWithPath = $"{path}/{fileName}";


            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imagePath.Split("/");
                string oldImageName = oldImagePart[^1];
                string imageCompleteOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(imageCompleteOldPath))
                {
                    System.IO.File.Delete(imageCompleteOldPath);
                }

            }

            return $"{basePath}/{fileName}";
        }

    }
}
