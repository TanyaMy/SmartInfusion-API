using System.Collections.Generic;
using BusinessLayer.Services.Abstractions;
using Common.Entities;
using DataLayer.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.Implementations
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public Treatment GetTreatmentById(int id)
        {
            return _treatmentRepository.GetSingleByPredicate(x => x.TreatmentId == id,
                include: x => x.Include(t => t.Medicine)
                                .Include(t => t.DiseaseHistory));
        }

        public IList<Treatment> GetTreatmentsByDiseaseHistoryId(int historyId)
        {
            return _treatmentRepository.GetAll(x => x.DiseaseHistoryId == historyId,
                 include: x => x.Include(t => t.Medicine)
                                .Include(t => t.DiseaseHistory));

        }

        public Treatment AddTreatment(Treatment treatment)
        {
            return _treatmentRepository.Add(treatment);
        }

        public void Update(Treatment treatment)
        {
            _treatmentRepository.Update(treatment);
        }
    }
}
