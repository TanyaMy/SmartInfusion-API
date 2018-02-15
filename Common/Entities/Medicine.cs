using Common.Entities.Base;
using System;

namespace Common.Entities
{
    public class Medicine : BaseEntity
    {
        public Int32 MedicineId { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }
    }
}
