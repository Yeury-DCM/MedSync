using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.ViewModels.Patients;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using MedSync.Presentation.Web.Middelware;
using Microsoft.AspNetCore.Mvc;

namespace MedSync.Presentation.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ValidateUserSession _validateUserSession;
        private readonly UserViewModel _userViewModel;

        public PatientController(IPatientService patientService, IHttpContextAccessor httpContext, ValidateUserSession validateUserSession)
        {
            _patientService = patientService;
            _httpContext = httpContext;
            _validateUserSession = validateUserSession;
            _userViewModel = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;


        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            return View(await _patientService.GetAllByDoctorOfficeAsync(_userViewModel.DoctorOfficeId));
        }

        public IActionResult Add()
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            return View("SavePatient");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SavePatientViewModel savePatientViewModel)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            ModelState.Remove("ImagePath");
            ModelState.Remove("DoctorOfficeId");
            ModelState.Remove("Id");

            if (!ModelState.IsValid)
            {
                return View("SavePatient", savePatientViewModel);
            }

            SavePatientViewModel patientViewModel = await _patientService.Add(savePatientViewModel);

            if (patientViewModel != null && patientViewModel.Id != 0)
            {
                patientViewModel.ImagePath = (UploadFile(savePatientViewModel.File, patientViewModel.Id));
                await _patientService.Update(patientViewModel);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            SavePatientViewModel savePatientViewModel = await _patientService.GetByIdSaveViewModel(id);

            return View("SavePatient", savePatientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePatientViewModel savePatientViewModel)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            ModelState.Remove("File");
            ModelState.Remove("ImagePath");


            if (!ModelState.IsValid)
            {

                return View("SavePatient", savePatientViewModel);
            }

            SavePatientViewModel savedDoctorViewModel = await _patientService.GetByIdSaveViewModel(savePatientViewModel.Id);

            savePatientViewModel.ImagePath = UploadFile(savePatientViewModel.File, savePatientViewModel.Id, true, savedDoctorViewModel.ImagePath);
            //  saveDoctorViewModel.

            await _patientService.Update(savePatientViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }


            PatientViewModel? patientViewModel = await _patientService.GetById(id);

            return View("DeletePatient", patientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.IsValidUser(UserType.Asistente))
            {
                return RedirectToRoute(new { controller = "Account", action = "Login" });
            }

            await _patientService.Delete(id);

            //Get Directory Path
            string basePath = $"/images/Patients/{id}";
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
            string basePath = $"/images/Patients/{id}";
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
