using BusinessLayer.Services.Abstractions;
using Common.Entities;
using Common.Entities.Identity;
using Common.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartInfusion.API.ViewModels;
using System;
using System.Linq;

namespace SmartInfusion.API.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        private readonly UserManager<AppUser> _userManager;

        public TreatmentController(
            ITreatmentService treatmentService,
            UserManager<AppUser> userManager)
        {
            _treatmentService = treatmentService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetTreatments(int id)
        {
            var result = ContentExecute<TreatmentListViewModel>(() =>
            {
                var treatments = _treatmentService.GetTreatmentsByDiseaseHistoryId(id);
                var medicineListItems = treatments.Select(x => new TreatmentListItemViewModel(x));
                return new TreatmentListViewModel()
                {
                    Treatments = medicineListItems.ToList()
                };
            });

            return Json(result);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetNotCompletedTreatments(int id)
        {
            var result = ContentExecute<TreatmentListViewModel>(() =>
            {
                var treatments = _treatmentService.GetTreatmentsByDiseaseHistoryId(id).Where(t => !t.IsCompleted);
                var medicineListItems = treatments.Select(x => new TreatmentListItemViewModel(x));
                return new TreatmentListViewModel()
                {
                    Treatments = medicineListItems.ToList()
                };
            });

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetTreatmentById(int id)
        {
            var result = ContentExecute<TreatmentListItemViewModel>(() =>
            {
                var treatment = _treatmentService.GetTreatmentById(id);
                return new TreatmentListItemViewModel(treatment);
            });

            return Json(result);
        }

        [HttpPost]
        public IActionResult AddTreatment(EditTreatmentViewModel model)
        {
            if (!ModelState.IsValid)
            {

            }

            var result = ContentExecute<TreatmentListItemViewModel>(() =>
            {
                var treatment = new Treatment
                {
                    MedicineId = model.MedicineId,
                    Diagnosis = model.Diagnosis,
                    SolutionVolume = model.SolutionVolume,
                    Dosage = model.Dosage,
                    InfusionSpeed = model.InfusionSpeed,
                    DiseaseHistoryId = model.DiseaseHistoryId
                };
                var newTreatment = _treatmentService.AddTreatment(treatment);
                return new TreatmentListItemViewModel(newTreatment);
            });

            return Json(result);
        }

        [HttpPut]
        public IActionResult EditTreatment(EditTreatmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
            }

            var result = Execute(() =>
            {
                var treatment = new Treatment
                {
                    Id = model.Id,
                    MedicineId = model.MedicineId,
                    Diagnosis = model.Diagnosis,
                    SolutionVolume = model.SolutionVolume,
                    InfusionSpeed = model.InfusionSpeed,
                    Dosage = model.Dosage,
                    DiseaseHistoryId = model.DiseaseHistoryId
                };
                _treatmentService.Update(treatment);
            });

            return Json(result);
        }
        
        public IActionResult CompleteTreatment(int id)
        {
            var result = Execute(() =>
            {
                bool isMedEmployee = _userManager.IsUserInMedEmployeeRole(User.Identity.Name);

                if (!isMedEmployee)
                {
                    throw new UnauthorizedAccessException("You have not appropriate rights to access this action");
                }

                _treatmentService.CompleteTreatment(id);

            });

            return Json(result);
        }
    }
}
