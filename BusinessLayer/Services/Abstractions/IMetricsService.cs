using Common.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Services.Abstractions
{
    public interface IMetricsService
    {
        IList<Metrics> GetAllMetrics();
        Metrics GetMetricsById(int id);

        IList<Metrics> GetMetricsByDiseaseHistoryId(int historyId);

        Metrics AddMetrics(Metrics  metrics);

        Metrics Update(Metrics metrics);
    }
}
