using System;
using System.Collections.Generic;

#nullable disable

namespace HealthyTeethAPI.Data
{
    public partial class ConsumableType
    {
        public ConsumableType()
        {
            Consumables = new HashSet<Consumable>();
        }

        public int ConsumableTypeId { get; set; }
        public string ConsumableTypeName { get; set; }

        public virtual ICollection<Consumable> Consumables { get; set; }
    }
}
