﻿using MedSync.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using MedSync.Core.Application.Helpers;
using MedSync.Core.Application.ViewModels.Users;
using MedSync.Core.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedSync.Core.Application.ViewModels.Appoiments;
using MedSync.Core.Application.Interfaces.Repositories;
namespace MedSync.Presentation.Web.Controllers
{
    public class AppoimentController : Controller
    {
        private readonly IAppoimentService _appoimentService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IHttpContextAccessor _httpContext;
        


        public AppoimentController(IAppoimentService userService, IHttpContextAccessor contextAccessor, IDoctorService doctorService, IPatientService patientService)
        {
            _appoimentService = userService;
            _httpContext = contextAccessor;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()

        {
            UserViewModel userLogedIn = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;

            return View(await _appoimentService.GetAllByDoctorOfficeAsync(userLogedIn.DoctorOfficeId));
        }

        public async Task <IActionResult> Add()
        {
            UserViewModel user = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!;
            ViewBag.Doctors = await _doctorService.GetAllByDoctorOfficeAsync(user.DoctorOfficeId);
            ViewBag.Patients = await _patientService.GetAllByDoctorOfficeAsync(user.DoctorOfficeId);

            return View("SaveAppoiment");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveAppoimentViewModel saveAppoiment)
        {
            ModelState.Remove("DoctorOfficeId");
            ModelState.Remove("LabTests");
            ModelState.Remove("Id");


            if (!ModelState.IsValid)
            {                    
                return View("saveAppoiment", saveAppoiment);
            }

            saveAppoiment.DoctorOfficeId = _httpContext.HttpContext!.Session.Get<UserViewModel>("user")!.DoctorOfficeId;
            await _appoimentService.Add(saveAppoiment);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {

            SaveAppoimentViewModel saveUserViewModel = await _appoimentService.GetByIdSaveViewModel(id);

            return View("SaveUser", saveUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveAppoimentViewModel saveAppoiment)
        {
      
            if (!ModelState.IsValid)
            {

                return View("SaveAppoiment", saveAppoiment);
            }

            await _appoimentService.Update(saveAppoiment);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            AppoimentViewModel? appoimentViewModel = await _appoimentService.GetById(id);

            return View("DeleteAppoiment", appoimentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _appoimentService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
