using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
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
  
        public int StorageId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Storage Storage { get; set; }
  
        public virtual ICollection<ConsumablesInDelivery> ConsumablesInDeliveries { get; set; }
    }
}
