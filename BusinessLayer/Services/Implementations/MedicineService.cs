using BusinessLayer.Services.Abstractions;
using Common.Entities;
using DataLayer.Repositories.Abstractions;
using System.Collections.Generic;

namespace BusinessLayer.Services.Implementations
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public IList<Medicine> GetAllMedicines()
        {
            return _medicineRepository.GetAll();
        }

        public Medicine GetMedicineById(int id)
        {
            return _medicineRepository.GetSingleByPredicate(x => x.MedicineId == id);
        }

        public Medicine GetMedicineByTitle(string title)
        {
            return _medicineRepository.GetSingleByPredicate(x => x.Title == title);
        }

        public Medicine Update(Medicine medicine)
        {
            return _medicineRepository.Update(medicine);
        }

        public Medicine AddMedicine(Medicine medicine)
        {
            return _medicineRepository.Add(medicine);
        }
    }
}
