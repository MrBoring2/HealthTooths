using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
{
    public partial class SpentConsumablesForVisit
    {
    
        public int СonsumableId { get; set; }
  
        public int VisitId { get; set; }
   
        public int Amount { get; set; }
   
        public virtual ClientsVisit Visit { get; set; }
     
        public virtual Consumable Сonsumable { get; set; }
    }
}
