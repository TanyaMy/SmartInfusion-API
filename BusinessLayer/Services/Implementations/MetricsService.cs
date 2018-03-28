using System.Collections.Generic;
using BusinessLayer.Services.Abstractions;
using Common.Entities;
using DataLayer.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.Implementations
{
    public class MetricsService : IMetricsService
    {
        private readonly IMetricsRepository _metricsRepository;

        public MetricsService(IMetricsRepository metricsRepository)
        {
            _metricsRepository = metricsRepository;
        }

        public IList<Metrics> GetAllMetrics()
        {
            return _metricsRepository.GetAll();
        }

        public Metrics GetMetricsById(int id)
        {
            return _metricsRepository.GetSingleByPredicate(x => x.MetricsId == id,
                    include: x => x.Include(t => t.DiseaseHistory));
        }

        public IList<Metrics> GetMetricsByDiseaseHistoryId(int historyId)
        {
            return _metricsRepository.GetAll(x => x.DiseaseHistoryId == historyId,
                    include: x => x.Include(t => t.DiseaseHistory));
        }

        public Metrics Update(Metrics metrics)
        {
            return _metricsRepository.Update(metrics);
        }

        public Metrics AddMetrics(Metrics metrics)
        {
            return _metricsRepository.Add(metrics);
        }
    }
}
