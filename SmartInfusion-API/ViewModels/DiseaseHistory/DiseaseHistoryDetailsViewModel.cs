using Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SmartInfusion.API.ViewModels
{
    public class DiseaseHistoryDetailsViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public UserInfoDetailedViewModel PatientInfo { get; set; }

        public List<MetricListItemViewModel> Metrics { get; set; }

        public List<TreatmentListItemViewModel> Treatments { get; set; }

        public DiseaseHistoryDetailsViewModel(DiseaseHistory history)
        {
            Id = history.Id;
            Message = history.Message;
            PatientInfo = new UserInfoDetailedViewModel(history.PatientInfo);
            Metrics = history.Metrics.Select(h => new MetricListItemViewModel(h)).ToList();
            Treatments = history.Treatments.Select(h => new TreatmentListItemViewModel(h)).ToList();
        }
    }
}
