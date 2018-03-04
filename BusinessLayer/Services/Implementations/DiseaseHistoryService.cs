using BusinessLayer.Services.Abstractions;
using Common.Entities;
using DataLayer.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BusinessLayer.Services.Implementations
{
    public class DiseaseHistoryService : IDiseaseHistoryService
    {
        private readonly IDiseaseHistoryRepository _diseaseHistoryRepository;

        public DiseaseHistoryService(IDiseaseHistoryRepository diseaseHistoryRepository)
        {
            _diseaseHistoryRepository = diseaseHistoryRepository;
        }

        public DiseaseHistory GetDiseaseHistoryById(int id)
        {
            return _diseaseHistoryRepository.GetSingleByPredicate(x => x.Id == id,
                include: x => x.Include(h => h.Treatments)
                                .Include(h => h.Metrics)
                                .Include(h => h.PatientInfo));
        }

        public DiseaseHistory GetDiseaseHistoryByPatientId(int id)
        {
            return _diseaseHistoryRepository.GetSingleByPredicate(x => x.PatientInfoId == id,
                include: x => x.Include(h => h.Treatments)
                     .Include(h => h.Metrics)
                     .Include(h => h.PatientInfo));
        }

        public IList<DiseaseHistory> GetAll()
        {
            return _diseaseHistoryRepository.GetAll(
                include: x => x.Include(h => h.Treatments)
                     .Include(h => h.Metrics)
                     .Include(h => h.PatientInfo));
        }

        public void Update(DiseaseHistory history)
        {
            _diseaseHistoryRepository.Update(history);
        }

        public DiseaseHistory AddDiseaseHistory(DiseaseHistory history)
        {
            return _diseaseHistoryRepository.Add(history);
        }
    }
}
