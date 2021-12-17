using System;
using System.Collections.Generic;

#nullable disable

namespace HealthyTeethAPI.Data
{
    public partial class Delivery
    {
        public Delivery()
        {
            ConsumablesInDeliveries = new HashSet<ConsumablesInDelivery>();
        }

        public int DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ConsumablesInDelivery> ConsumablesInDeliveries { get; set; }
    }
}
