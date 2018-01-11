using Common.Entities.OrganRequests;
using SmartInfusion.API.ViewModels.UserInfo;

namespace SmartInfusion.API.ViewModels.PatientRequests
{
    public class PatientRequestDetailsViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public int? PatientInfoId { get; set; }
        public UserInfoDetailedViewModel PatientInfo { get; set; }

        public int OrganInfoId { get; set; }

        public PatientRequestDetailsViewModel(PatientRequest request)
        {
            Id = request.Id;
            Message = request.Message;
            PatientInfoId = request.PatientInfoId;
            PatientInfo = new UserInfoDetailedViewModel(request.PatientInfo);
        }

        public PatientRequestDetailsViewModel() { }
    }
}
