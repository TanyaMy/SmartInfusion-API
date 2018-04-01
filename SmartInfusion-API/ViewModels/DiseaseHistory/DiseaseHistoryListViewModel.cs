using System.Collections.Generic;

namespace SmartInfusion.API.ViewModels
{
    public class DiseaseHistoryListViewModel
    {
        public ICollection<DiseaseHistoryListItemViewModel> DiseaseHistoryList { get; set; }

        public DiseaseHistoryListViewModel(ICollection<DiseaseHistoryListItemViewModel> list)
        {
            DiseaseHistoryList = list;
        }

        public DiseaseHistoryListViewModel() { }
    }
}
