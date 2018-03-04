using Common.Entities;
using DataLayer.DbContext;
using DataLayer.Repositories.Abstractions;

namespace DataLayer.Repositories.Implementations
{
    public class TreatmentRepository : RepositoryBase<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(AppDbContext dbContext)
            : base(dbContext, dbContext.Treatments)
        {
        }
    }
}
