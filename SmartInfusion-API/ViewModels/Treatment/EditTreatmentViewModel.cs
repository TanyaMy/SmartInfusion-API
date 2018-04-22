using System;

namespace SmartInfusion.API.ViewModels
{
    public class EditTreatmentViewModel
    {
        public int Id { get; set; }

        public int MedicineId { get; set; }

        public string Diagnosis { get; set; }

        public double MedicineWeight { get; set; }

        public double SolutionVolume { get; set; }

        public double Dosage { get; set; }

        public int DiseaseHistoryId { get; set; }

        public DateTime Created { get; set; }

        public bool IsCompleted { get; set; }
    }
}
