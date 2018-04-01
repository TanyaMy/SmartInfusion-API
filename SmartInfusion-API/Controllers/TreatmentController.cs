using BusinessLayer.Services.Abstractions;
using Common.Entities;
using Common.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartInfusion.API.ViewModels;
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
        public IActionResult GetTreatments(int diseaseHistoryId)
        {
            var result = ContentExecute<TreatmentListViewModel>(() =>
            {
                var treatments = _treatmentService.GetTreatmentsByDiseaseHistoryId(diseaseHistoryId);
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
            var result = ContentExecute<Treatment>(() =>
            {
                var treatment = _treatmentService.GetTreatmentById(id);
                return treatment;
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
                    MedicineWeight = model.MedicineWeight,
                    SolutionVolume = model.SolutionVolume,
                    Dosage = model.Dosage,
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

            var result = ContentExecute<TreatmentListItemViewModel>(() =>
            {
                var treatment = new Treatment
                {
                    Id = model.Id,
                    MedicineId = model.MedicineId,
                    Diagnosis = model.Diagnosis,
                    MedicineWeight = model.MedicineWeight,
                    SolutionVolume = model.SolutionVolume,
                    Dosage = model.Dosage,
                    DiseaseHistoryId = model.DiseaseHistoryId
                };
                var newTreatment = _treatmentService.AddTreatment(treatment);
                return new TreatmentListItemViewModel(newTreatment);
            });

            return Json(result);
        }
    }
}
