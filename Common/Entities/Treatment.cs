using Common.Entities.Base;

namespace Common.Entities
{
    public class Treatment : BaseEntity
    {
        public int TreatmentId { get; set; }

        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        public string Diagnosis { get; set; }

        public double MedicineWeight { get; set; }

        public double SolutionVolume { get; set; }

        public double Dosage { get; set; }

        public int DiseaseHistoryId { get; set; }

        public DiseaseHistory DiseaseHistory { get; set; }
    }
}
