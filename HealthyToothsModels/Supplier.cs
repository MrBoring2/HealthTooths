using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
{
    public partial class Supplier
    {
        public Supplier()
        {
            Deliveries = new HashSet<Delivery>();
        }

 
        public int SupplierId { get; set; }
   
        public string SupplierName { get; set; }

        public string SupplierAddress { get; set; }
  
        public virtual ICollection<Delivery> Deliveries { get; set; }
    }
}
