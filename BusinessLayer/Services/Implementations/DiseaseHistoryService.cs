using BusinessLayer.Services.Abstractions;
using Common.Entities;
using Common.Entities.Identity;
using DataLayer.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services.Implementations
{
    public class DiseaseHistoryService : IDiseaseHistoryService
    {
        private readonly IDiseaseHistoryRepository _diseaseHistoryRepository;
        private readonly UserManager<AppUser> _userManager;

        public DiseaseHistoryService(IDiseaseHistoryRepository diseaseHistoryRepository,
            UserManager<AppUser> userManager)
        {
            _diseaseHistoryRepository = diseaseHistoryRepository;
            _userManager = userManager;
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

        public IList<DiseaseHistory> GetDiseaseHistoriesByUsername(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            return _diseaseHistoryRepository.GetAll(
                predicate: dh => dh.PatientInfo.AppUserId == user.Id,
                include: x => x.Include(p => p.Metrics)
                    .Include(p => p.Treatments)
                    .Include(p => p.PatientInfo))
                    .OrderBy(p => p.Created)
                    .ToList();
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
