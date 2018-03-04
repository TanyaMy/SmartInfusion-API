using Common.Entities;
using DataLayer.DbContext;
using DataLayer.Repositories.Abstractions;

namespace DataLayer.Repositories.Implementations
{
    public class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
    {
        public MedicineRepository(AppDbContext dbContext)
            : base(dbContext, dbContext.Medicines)
        {
        }
    }
}
