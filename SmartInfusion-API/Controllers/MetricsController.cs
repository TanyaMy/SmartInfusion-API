using BusinessLayer.Services.Abstractions;
using Common.Entities;
using Common.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartInfusion.API.ViewModels;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult GetMetrics()
        {
            var result = ContentExecute<MetricListViewModel>(() =>
            {
                var metrics = _metricsService.GetAllMetrics();
                var metricListItems = metrics.Select(x => new MetricListItemViewModel(x));
                return new MetricListViewModel()
                {
                    Metrics = metricListItems.ToList()
                };
            });

            return Json(result);
        }

        [HttpGet]
        public IActionResult GetMetricById(int id)
        {
            var result = ContentExecute<Metrics>(() =>
            {
                var metrics = _metricsService.GetMetricsById(id);
                return metrics;
            });

            return Json(result);
        }

        [HttpPost]
        public IActionResult AddMedicine(EditMetricViewModel model)
        {
            if (!ModelState.IsValid)
            {

            }

            var result = ContentExecute<MetricListItemViewModel>(() =>
            {
                var metrics = new Metrics
                {
                   Name = model.Name,
                   Value = model.Value,
                   DiseaseHistoryId = model.DiseaseHistoryId
                };
                var newMetrics = _metricsService.AddMetrics(metrics);
                return new MetricListItemViewModel(newMetrics);
            });

            return Json(result);
        }

        [HttpPut]
        public IActionResult EditMetrics(EditMetricViewModel model)
        {
            if (!ModelState.IsValid)
            {
            }

            var result = ContentExecute<MetricListItemViewModel>(() =>
            {
                var metrics = new Metrics
                {
                    Id = model.Id,
                    Name = model.Name,
                    Value = model.Value,
                    DiseaseHistoryId = model.DiseaseHistoryId
                };
                var newMetrics = _metricsService.Update(metrics);
                return new MetricListItemViewModel(newMetrics);
            });

            return Json(result);
        }
    }
}
