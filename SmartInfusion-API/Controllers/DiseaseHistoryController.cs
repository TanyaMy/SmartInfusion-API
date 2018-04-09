using BusinessLayer.Models.ViewModels.Patient;
using BusinessLayer.Services.Abstractions;
using Common.Constants;
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
    public class DiseaseHistoryController : ControllerBase
    {
        private readonly IDiseaseHistoryService _diseaseHistoryService;
        private readonly IUserInfoService _userInfoService;
        private readonly UserManager<AppUser> _userManager;

        public DiseaseHistoryController(
            IDiseaseHistoryService diseaseHistoryService,
            IUserInfoService userInfoService,
            UserManager<AppUser> userManager)
        {
            _diseaseHistoryService = diseaseHistoryService;
            _userInfoService = userInfoService;
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
                var username = User.Identity.Name;
                var user = _userManager.FindByNameAsync(username).Result;
                var isMedEmployee = _userManager.IsInRoleAsync(user, RolesConstants.MedicalEmployee).Result;
                var histories = isMedEmployee
                    ? _diseaseHistoryService.GetAll()
                    : _diseaseHistoryService.GetDiseaseHistoriesByUsername(user.UserName);

                var historiesListItems = histories.Select(h => new DiseaseHistoryListItemViewModel(h)).ToList();
                return new DiseaseHistoryListViewModel(historiesListItems);
            });

            return Json(response);
        }

        [HttpGet]
        public IActionResult GetDiseaseHistoryDetails(int id)
        {
            var response = ContentExecute(() =>
            {
                var username = User.Identity.Name;
                var history = _diseaseHistoryService.GetDiseaseHistoryById(id);
                
                return new DiseaseHistoryDetailsViewModel(history);
            });

            return Json(response);
        }

        [HttpPost]
        public IActionResult CreateDiseaseHistory(PatientViewModel model)
        {
            var result = Execute(() =>
            {
                bool isMedEmployee = _userManager.IsUserInMedEmployeeRole(User.Identity.Name);
                if (!isMedEmployee)
                {
                    throw new UnauthorizedAccessException("You have not appropriate rights to access this action");
                }


                var patientUserInfo = _userInfoService.RegisterPatient(model);


                var diseaseHistory = new DiseaseHistory()
                {
                    PatientInfoId = patientUserInfo.UserInfoId,
                    PatientInfo = patientUserInfo,
                    Message = model.Message
                };


                _diseaseHistoryService.AddDiseaseHistory(diseaseHistory);
            });

            return Json(result);
        }
    }
}
