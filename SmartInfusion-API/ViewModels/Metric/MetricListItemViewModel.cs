using Common.Entities;

namespace SmartInfusion.API.ViewModels
{
    public class MetricListItemViewModel
    {
        public MetricListItemViewModel(Metrics metric)
        {
            Id = metric.Id;
            Name = metric.Name;
            Value = metric.Value;
            DiseaseHistoryId = metric.DiseaseHistoryId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int DiseaseHistoryId { get; set; }
    }
}
