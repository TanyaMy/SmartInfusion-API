using BusinessLayer.Services.Abstractions;
using Common.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}
