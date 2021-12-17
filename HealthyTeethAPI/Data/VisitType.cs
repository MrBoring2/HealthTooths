using System;
using System.Collections.Generic;

#nullable disable

namespace HealthyTeethAPI.Data
{
    public partial class VisitType
    {
        public VisitType()
        {
            ClientsVisits = new HashSet<ClientsVisit>();
        }

        public int VisitTypeId { get; set; }
        public string VisitTypeName { get; set; }

        public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
    }
}
