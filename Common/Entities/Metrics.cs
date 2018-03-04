using Common.Entities.Base;

namespace Common.Entities
{
    public class Metrics : BaseEntity
    {
        public int MetricsId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int DiseaseHistoryId { get; set; }

        public DiseaseHistory DiseaseHistory { get; set; }
    }
}
