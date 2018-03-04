using Common.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Services.Abstractions
{
    public interface IMetricsService
    {
        Metrics GetMetricsById(int id);

        IList<Metrics> GetMetricsByDiseaseHistoryId(int historyId);

        Metrics AddMetrics(Metrics  metrics);

        void Update(Metrics metrics);
    }
}
