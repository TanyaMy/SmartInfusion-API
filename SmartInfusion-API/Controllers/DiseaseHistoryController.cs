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
    public class DiseaseHistoryController : ControllerBase
    {
        private readonly IDiseaseHistoryService _diseaseHistoryService;
        private readonly UserManager<AppUser> _userManager;

        public DiseaseHistoryController(
            IDiseaseHistoryService diseaseHistoryService,
            UserManager<AppUser> userManager)
        {
            _diseaseHistoryService = diseaseHistoryService;
            _userManager = userManager;
        }

        [HttpGet]        
        public IActionResult GetDiseaseHistory(int id)
        {
            var response = ContentExecute(() =>
            {
                int patientId = id;
                return _diseaseHistoryService.GetDiseaseHistoryByPatientId(patientId);
            });

            return Json(response);
        }

        [HttpGet]
        public IActionResult GetDiseaseHistories()
        {
            var response = ContentExecute(() =>
            {
                return _diseaseHistoryService.GetAll();
            });

            return Json(response);
        }
    }
}
