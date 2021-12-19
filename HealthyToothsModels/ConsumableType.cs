using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
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
