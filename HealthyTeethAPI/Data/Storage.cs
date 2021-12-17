using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyTeethAPI.Data
{
    public partial class Storage
    {
        [Key]
        public int StorageId { get; set; }
        public string StorageName { get; set; }
        public virtual ICollection<ConsumablesInStorage> ConsumablesInStorages { get; set; }
    }
}
