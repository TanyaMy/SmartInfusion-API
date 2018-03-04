using Common.Entities;
using DataLayer.DbContext;
using DataLayer.Repositories.Abstractions;

namespace DataLayer.Repositories.Implementations
{
    public class DiseaseHistoryRepository : RepositoryBase<DiseaseHistory>, IDiseaseHistoryRepository
    {
        public DiseaseHistoryRepository(AppDbContext dbContext)
            : base(dbContext, dbContext.DiseaseHistories)
        {
        }
    }
}
