using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
{
    public partial class VisitType
    {
        public VisitType()
        {
            ClientsVisits = new HashSet<ClientsVisit>();
        }

   
        public int VisitTypeId { get; set; }

        public string VisitTypeName { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
    }
}
