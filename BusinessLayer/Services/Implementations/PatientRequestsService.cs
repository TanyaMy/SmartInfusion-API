using BusinessLayer.Services.Abstractions;
using DataLayer.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using Common.Entities.Identity;
using Common.Entities.OrganRequests;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Common.Models;

namespace BusinessLayer.Services.Implementations
{
    public class PatientRequestsService : IPatientRequestsService
    {
        private readonly IPatientRequestsRepository _patientRequestsRepository;
        private readonly IUserInfoService _userInfoService;
        private readonly UserManager<AppUser> _userManager;

        public PatientRequestsService(
            IPatientRequestsRepository patientRequestsRepository,
            IUserInfoService userInfoService,
            UserManager<AppUser> userManager)
        {
            _patientRequestsRepository = patientRequestsRepository;
            _userInfoService = userInfoService;
            _userManager = userManager;
        }

        public IList<PatientRequest> GetPatientRequests()
        {
            return _patientRequestsRepository.GetAll(
           include: x => x.Include(p => p.PatientInfo))
                    .OrderBy(p => p.Created)
                    .ToList();
        }

        public IList<PatientRequest> GetPatientRequestsByUsername(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            return _patientRequestsRepository.GetAll(
                predicate: dr => dr.PatientInfo.AppUserId == user.Id,
                include: x => x.Include(p => p.PatientInfo))
                    .OrderBy(p => p.Created)
                    .ToList();
        }

        public PatientRequest GetById(int patientOrganRequestId)
        {
            return _patientRequestsRepository.GetById(patientOrganRequestId);
        }

        public PatientRequest GetDetailedById(int id)
        {
            return _patientRequestsRepository.GetDetailedById(id);
        }
        
        public void UpdatePatientRequestWithPatient(EditPatientRequestModel model)
        {
            var patRequest = _patientRequestsRepository.GetById(model.PatientRequestId);
            if (patRequest == null)
            {
                return;
            }

            patRequest.Message = model.Message;
            _patientRequestsRepository.Update(patRequest);

            if (patRequest.PatientInfoId.HasValue)
            {
                var patient = _userInfoService.GetUserInfoById(patRequest.PatientInfoId.Value);

                patient.AddressLine1 = model.PatientAddressLine1;
                patient.PhoneNumber = model.PatientPhoneNumber;

                _userInfoService.Update(patient);
            }
        }
    }
}
