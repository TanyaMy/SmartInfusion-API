using System;
using BusinessLayer.Models.ViewModels;
using BusinessLayer.Services.Abstractions;
using Common.Constants;
using Common.Entities.Identity;
using Common.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SmartInfusion.API.ViewModels.PatientRequests;
using Common.Models;

namespace SmartInfusion.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]/{id?}")]
    public class PatientRequestController : ControllerBase
    {
        private readonly IPatientRequestsService _patientRequestService;
        private readonly UserManager<AppUser> _userManager;

        public PatientRequestController(
            IPatientRequestsService patientOrganRequestService,
            UserManager<AppUser> userManager)
        {
            _patientRequestService = patientOrganRequestService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetPatientRequest(int id)
        {
            var result = ContentExecute(() =>
            {
                int patientRequestId = id;
                return _patientRequestService.GetById(patientRequestId);
            });

            return Json(result);
        }

        /// <summary>
        /// Returns Patient Requests List
        /// </summary>
        [HttpGet]
        public IActionResult GetPatientRequestList()
        {
            var response = ContentExecute(() =>
            {
                var username = User.Identity.Name;
                var user = _userManager.FindByNameAsync(username).Result;
                var isMedEmployee = _userManager.IsInRoleAsync(user, RolesConstants.MedicalEmployee).Result;
                var patientRequests = isMedEmployee
                    ? _patientRequestService.GetPatientRequests()
                    : _patientRequestService.GetPatientRequestsByUsername(user.UserName);

                var patientRequestListItems = patientRequests.Select(dr => new PatientRequestListItemViewModel(dr)).ToList();
                return new PatientRequestListViewModel(patientRequestListItems);
            });


            return Json(response);
        }

       
        /// <summary>
        /// Returns Patient Requests List
        /// </summary>
        [HttpGet]
        public IActionResult GetPatientRequestDetails(int id)
        {
            int patientRequestId = id;
            bool hasRights = _userManager.IsUserInMedEmployeeRole(User.Identity.Name);
            if (!hasRights)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
              //  hasRights = _patientRequestService.HasPatientRequest(user.Id, patientRequestId);
            }
            if (!hasRights)
            {
                return Unauthorized();
            }

            var response = ContentExecute<PatientRequestDetailsViewModel>(() =>
            {
                var patientRequest = _patientRequestService.GetDetailedById(patientRequestId);
                return new PatientRequestDetailsViewModel(patientRequest);
            });

            return Json(response);
        }

        /// <summary>
        /// Creates User/UserInfo for donor and sends email to donor
        /// Creates new PatientOrganQuery for patient
        /// </summary>
        [HttpPost]
        public IActionResult CreatePatientRequest(PatientOrganRequestViewModel model)
        {
            var result = Execute(() =>
            {
                bool isMedEmployee = _userManager.IsUserInMedEmployeeRole(User.Identity.Name);
                if (!isMedEmployee)
                {
                    throw new UnauthorizedAccessException("You have not appropriate rights to access this action");
                }

                //_patientRequestService.AddPatientRequAdestToQueue(model);
            });

            return Json(result);
        }

        [HttpPost]
        public IActionResult UpdatePatientRequest(EditPatientRequestModel model)
        {
            var result = Execute(() =>
            {
                _patientRequestService.UpdatePatientRequestWithPatient(model);
            });

            return Json(result);
        }
    }
}
