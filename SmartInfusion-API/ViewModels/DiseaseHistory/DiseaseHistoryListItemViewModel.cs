using Common.Entities;
using System;

namespace SmartInfusion.API.ViewModels
{
    public class DiseaseHistoryListItemViewModel
    {
        public int Id { get; set; }

        public int PatientInfoId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime? BirthDate { get; set; }

        public DiseaseHistoryListItemViewModel(DiseaseHistory history)
        {
            Id = history.Id;
            PatientInfoId = history.PatientInfoId;
            Email = history.PatientInfo.Email;
            FirstName = history.PatientInfo.FirstName;
            SecondName = history.PatientInfo.SecondName;
            BirthDate = history.PatientInfo.BirthDate;
        }
    }
}
