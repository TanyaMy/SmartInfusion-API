using BusinessLayer.Services.Abstractions;
using Common.Entities;
using Common.Entities.Identity;
using DataLayer.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Services.Implementations
{
    public class UserInfoService : IUserInfoService
    {
        private const string UserCreationFailedErrorMessage = "Error while creating a user";

        private readonly IUserInfoRepository _userInfoRepository;
        private readonly UserManager<AppUser> _userManager;

        public UserInfoService(IUserInfoRepository userInfoRepository,
            UserManager<AppUser> userManager)
        {
            _userInfoRepository = userInfoRepository;
            _userManager = userManager;
        }

        public UserInfo GetUserInfoById(int id)
        {
            return _userInfoRepository.GetSingleByPredicate(x => x.UserInfoId == id);
        }

        public UserInfo GetUserInfoByUserId(string id)
        {
            return _userInfoRepository.GetSingleByPredicate(x => x.AppUserId == id);
        }

        //public UserInfo RegisterPatient(PatientMedicineViewModel model)
        //{
        //    var patientInfo = new UserInfo()
        //    {
        //        FirstName = model.FirstName,
        //        SecondName = model.SecondName,
        //        Country = model.Country,
        //        City = model.City,
        //        AddressLine1 = model.AddressLine1,
        //        AddressLine2 = model.AddressLine2,
        //        Email = model.Email,
        //        PhoneNumber = model.PhoneNumber,
        //        ZipCode = model.ZipCode
        //    };

        //    AppUser user = new AppUser()
        //    {
        //        Email = model.Email,
        //        UserName = model.Email,
        //        Created = DateTime.UtcNow,
        //        CreatedBy = "CurrentUser",
        //        EmailConfirmed = true,
        //        PhoneNumber = model.PhoneNumber,
        //        PhoneNumberConfirmed = true,
        //        UserInfo = patientInfo
        //    };

        //    var password = PasswordHasher.GetStaticPassword();
        //    var result = _userManager.CreateAsync(user, password).Result;

        //    if (result.Succeeded)
        //    {
        //        result = _userManager.AddToRoleAsync(user, RolesConstants.Patient).Result;
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException(UserCreationFailedErrorMessage);
        //    }

        //    if (!result.Succeeded)
        //    {
        //        _userManager.DeleteAsync(user).Wait();
        //        throw new InvalidOperationException(UserCreationFailedErrorMessage);
        //    }

        //    return patientInfo;
        //}

        public void Update(UserInfo patient)
        {
            _userInfoRepository.Update(patient);
        }
    }
}
