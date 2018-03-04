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
    }
}
