using Common.Entities;

namespace SmartInfusion.API.ViewModels
{
    public class MetricListItemViewModel
    {
        public MetricListItemViewModel(Metrics metric)
        {
            MetricsId = metric.MetricsId;
            Name = metric.Name;
            Value = metric.Value;
            DiseaseHistoryId = metric.DiseaseHistoryId;
        }

        public int MetricsId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int DiseaseHistoryId { get; set; }
    }
}
