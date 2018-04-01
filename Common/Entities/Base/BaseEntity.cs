using Newtonsoft.Json;
using System;

namespace Common.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        [JsonIgnore]
        public string CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime Created { get; set; }

        [JsonIgnore]
        public string UpdatedBy { get; set; }

        [JsonIgnore]
        public DateTime? Updated { get; set; }
    }
}