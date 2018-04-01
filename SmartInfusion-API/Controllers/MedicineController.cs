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
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly UserManager<AppUser> _userManager;

        public MedicineController(
            IMedicineService medicineService,
            UserManager<AppUser> userManager)
        {
            _medicineService = medicineService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetMedicines()
        {
            var result = ContentExecute<MedicineListViewModel>(() =>
            {
                var medicines = _medicineService.GetAllMedicines();
                var medicineListItems = medicines.Select(x => new MedicineListItemViewModel(x));
                return new MedicineListViewModel()
                {
                    Medicines = medicineListItems.ToList()
                };
            });

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetMedicineById(int id)
        {
            var result = ContentExecute<Medicine>(() =>
            {
                var medicine = _medicineService.GetMedicineById(id);
                return medicine;
            });

            return Json(result);
        }

        [HttpPost]
        public IActionResult AddMedicine(MedicineListItemViewModel model)
        {
            if (!ModelState.IsValid)
            {

            }

            var result = ContentExecute<MedicineListItemViewModel>(() =>
            {
                var medicine = new Medicine
                {
                    Title = model.Title,
                    Description = model.Description,
                };
                var newMedicine = _medicineService.AddMedicine(medicine);
                return new MedicineListItemViewModel(newMedicine);
            });

            return Json(result);
        }

        [HttpPut]
        public IActionResult EditMedicine(MedicineListItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
            }

            var result = ContentExecute<MedicineListItemViewModel>(() =>
            {
                var medicine = new Medicine
                {
                    MedicineId = model.MedicineId,
                    Title = model.Title,
                    Description = model.Description
                };
                var newMedicine = _medicineService.Update(medicine);
                return new MedicineListItemViewModel(newMedicine);
            });

            return Json(result);
        }
    }
}
