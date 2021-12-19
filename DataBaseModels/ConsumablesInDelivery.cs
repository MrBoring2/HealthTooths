using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseModels
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
