using Common.Entities;
using System;

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
            Created = metric.Created;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int DiseaseHistoryId { get; set; }

        public DateTime Created { get; set; }
    }
}
