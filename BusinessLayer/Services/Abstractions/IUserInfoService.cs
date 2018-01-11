using BusinessLayer.Models.ViewModels;
using Common.Entities;

namespace BusinessLayer.Services.Abstractions
{
    public interface IUserInfoService
    {
        UserInfo GetUserInfoById(int id);

        UserInfo GetUserInfoByUserId(string id);

        UserInfo RegisterPatient(PatientOrganRequestViewModel model);

        void Update(UserInfo patient);
    }
}
