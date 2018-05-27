using Common.Entities.Base;

namespace Common.Entities
{
    public class Treatment : BaseEntity
    {
        public int Id { get; set; }

        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        public string Diagnosis { get; set; }

        public double SolutionVolume { get; set; }

        public double Dosage { get; set; }

        public double InfusionSpeed { get; set; }

        public int DiseaseHistoryId { get; set; }

        public bool IsCompleted { get; set; }

        public DiseaseHistory DiseaseHistory { get; set; }
    }
}
