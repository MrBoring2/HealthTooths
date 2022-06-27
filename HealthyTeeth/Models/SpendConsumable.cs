using HealthyToothsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTeeth.Models
{
    public class SpendConsumable
    {
        public Consumable Consumable { get; set; }
        public int ConsumableAmount { get; set; }
        public string ConsumableName => Consumable.ConsumableName;
    }
}
