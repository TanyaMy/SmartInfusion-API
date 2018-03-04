using Common.Entities;
using DataLayer.DbContext;
using DataLayer.Repositories.Abstractions;

namespace DataLayer.Repositories.Implementations
{
    public class MetricsRepository : RepositoryBase<Metrics>, IMetricsRepository
    {
        public MetricsRepository(AppDbContext dbContext)
            : base(dbContext, dbContext.Metrics)
        {
        }
    }
}
