using Common.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Services.Abstractions
{
    public interface IMedicineService
    {
        Medicine GetMedicineById(int id);

        Medicine GetMedicineByTitle(string title);

        Medicine AddMedicine(Medicine mdeicine);

        void Update(Medicine mdeicine);
    }
}
