using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
{
    public partial class Consumable : BaseModel
    {
        public Consumable()
        {
            ConsumablesInDeliveries = new HashSet<ConsumablesInDelivery>();
            SpentConsumablesForVisits = new HashSet<SpentConsumablesForVisit>();
            ConsumablesInStorages = new HashSet<ConsumablesInStorage>();
        }


        public int ConsumableId { get; set; }

        public string ConsumableName { get; set; }

        public int ConsumableTypeId { get; set; }

        public double Price { get; set; }

        public virtual ConsumableType ConsumableType { get; set; }
        public virtual ICollection<ConsumablesInDelivery> ConsumablesInDeliveries { get; set; }
        public virtual ICollection<ConsumablesInStorage> ConsumablesInStorages { get; set; }
        public virtual ICollection<SpentConsumablesForVisit> SpentConsumablesForVisits { get; set; }
        public string TotalAmountInStorages
        {
            get
            {
                string amount = "";
                if (ConsumablesInStorages.Count > 0)
                {
                    foreach (var item in ConsumablesInStorages)
                    {
                        if (item.Storage != null)
                        {
                            amount += $"{item.Amount} шт. на складе {item.Storage.StorageName}\n";
                        }
                    }
                }
                else
                {
                    amount += "Нет в наличии на складах";
                }
                return amount;
            }
        }
    }
}
