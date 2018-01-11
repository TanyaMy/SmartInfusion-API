using Common.Entities.OrganRequests;
using Common.Enums;

namespace SmartInfusion.API.ViewModels.PatientRequests
{
    public class PatientRequestListItemViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Message { get; set; }

        public int? PatientInfoId { get; set; }

        public PatientRequestListItemViewModel(PatientRequest patientRequest)
        {
            Id = patientRequest.Id;
            Message = patientRequest.Message;
            FullName = patientRequest.PatientInfo.FirstName + " " + patientRequest.PatientInfo.SecondName;
            PatientInfoId = patientRequest.PatientInfoId;
        }
    }
}
