using HealthyToothsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTeeth.Models
{
    public class DeliveryConsumable
    {
        public Consumable Consumable { get; set; }
        public int ConsumableAmount { get; set; }
        public double Price => Consumable.Price;
        public string ConsumableName => Consumable.ConsumableName;
    }
}
