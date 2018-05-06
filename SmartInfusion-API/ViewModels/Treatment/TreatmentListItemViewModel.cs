using Common.Entities;
using System;

namespace SmartInfusion.API.ViewModels
{
    public class TreatmentListItemViewModel
    {
        public int Id { get; set; }

        public int MedicineId { get; set; }

        public string MedicineTitle { get; set; }

        public string Diagnosis { get; set; }

        public double MedicineWeight { get; set; }

        public double SolutionVolume { get; set; }

        public double Dosage { get; set; }

        public int DiseaseHistoryId { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime Created { get; set; }

        public TreatmentListItemViewModel(Treatment treatment)
        {
            Id = treatment.Id;
            MedicineId = treatment.MedicineId;
            MedicineTitle = treatment.Medicine?.Title;
            Diagnosis = treatment.Diagnosis;
            MedicineWeight = treatment.MedicineWeight;
            SolutionVolume = treatment.SolutionVolume;
            Dosage = treatment.Dosage;
            DiseaseHistoryId = treatment.DiseaseHistoryId;
            IsCompleted = treatment.IsCompleted;
            Created = treatment.Created;
        }
    }
}
