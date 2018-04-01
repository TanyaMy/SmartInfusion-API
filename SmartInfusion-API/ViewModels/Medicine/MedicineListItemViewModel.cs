using Common.Entities;
using System;

namespace SmartInfusion.API.ViewModels
{
    public class MedicineListItemViewModel
    {
        public MedicineListItemViewModel(Medicine medicine)
        {
            Id = medicine.Id;
            Title = medicine.Title;
            Description = medicine.Description;
        }

        public Int32 Id { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }
    }
}
