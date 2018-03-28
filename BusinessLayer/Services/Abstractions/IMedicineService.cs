using Common.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Services.Abstractions
{
    public interface IMedicineService
    {
        IList<Medicine> GetAllMedicines();
        Medicine GetMedicineById(int id);

        Medicine GetMedicineByTitle(string title);

        Medicine AddMedicine(Medicine mdeicine);

        Medicine Update(Medicine mdeicine);
    }
}
