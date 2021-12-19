using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
{
    public partial class ConsumablesInDelivery
    {

        public int DeliveryId { get; set; }
 
        public int ConsumableId { get; set; }

        public int Amount { get; set; }
 
        public virtual Consumable Consumable { get; set; }
    
        public virtual Delivery Delivery { get; set; }
    }
}
