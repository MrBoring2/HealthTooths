using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyTeethAPI.Data
{
    public partial class ConsumablesInStorage
    {
        public int StorageId { get; set; }
        public int ConsumableId { get; set; }
        public int Amount { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Consumable Consumable { get; set; }
    }
}
