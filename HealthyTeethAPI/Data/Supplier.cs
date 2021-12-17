using System;
using System.Collections.Generic;

#nullable disable

namespace HealthyTeethAPI.Data
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
