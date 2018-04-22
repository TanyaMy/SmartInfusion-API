using Common.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Services.Abstractions
{
    public interface ITreatmentService
    {
        Treatment GetTreatmentById(int id);

        IList<Treatment> GetTreatmentsByDiseaseHistoryId(int historyId);

        Treatment AddTreatment(Treatment treatment);

        void Update(Treatment treatment);

        void CompleteTreatment(int id);
    }
}
