using Common.Entities.Base;

namespace Common.Entities.OrganRequests
{
    public class PatientRequest : BaseEntity
    {
        public int Id { get; set; }

        public string Message { get; set; }
        public int? PatientInfoId { get; set; }
        public UserInfo PatientInfo { get; set; }
    }
}
