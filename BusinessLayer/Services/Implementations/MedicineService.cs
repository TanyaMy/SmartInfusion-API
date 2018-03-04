using BusinessLayer.Services.Abstractions;
using Common.Entities;
using DataLayer.Repositories.Abstractions;

namespace BusinessLayer.Services.Implementations
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public Medicine GetMedicineById(int id)
        {
            return _medicineRepository.GetSingleByPredicate(x => x.MedicineId == id);
        }

        public Medicine GetMedicineByTitle(string title)
        {
            return _medicineRepository.GetSingleByPredicate(x => x.Title == title);
        }

        public void Update(Medicine medicine)
        {
            _medicineRepository.Update(medicine);
        }

        public Medicine AddMedicine(Medicine medicine)
        {
            return _medicineRepository.Add(medicine);
        }
    }
}
