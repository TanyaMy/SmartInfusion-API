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
    public class MetricsController : ControllerBase
    {
        private readonly IMetricsService _metricsService;
        private readonly UserManager<AppUser> _userManager;

        public MetricsController(
            IMetricsService metricsService,
            UserManager<AppUser> userManager)
        {
            _metricsService = metricsService;
            _userManager = userManager;
        }
    }
}
