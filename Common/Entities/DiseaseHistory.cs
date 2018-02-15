using Common.Entities.Base;
using System.Collections.Generic;

namespace Common.Entities
{
    public class DiseaseHistory : BaseEntity
    {
        public int Id { get; set; }

        public int PatientInfoId { get; set; }

        public UserInfo PatientInfo { get; set; }

        public List<Treatment> Treatments { get; set; }
    }
}
