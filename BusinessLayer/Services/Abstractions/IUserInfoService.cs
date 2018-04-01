using BusinessLayer.Models.ViewModels.Patient;
using Common.Entities;

namespace BusinessLayer.Services.Abstractions
{
    public interface IUserInfoService
    {
        UserInfo GetUserInfoById(int id);

        UserInfo GetUserInfoByUserId(string id);

        UserInfo RegisterPatient(PatientViewModel model);

        void Update(UserInfo patient);
    }
}
