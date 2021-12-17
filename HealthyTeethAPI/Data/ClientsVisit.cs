using System;
using System.Collections.Generic;

#nullable disable

namespace HealthyTeethAPI.Data
{
    public partial class ClientsVisit
    {
        public ClientsVisit()
        {
            SpentConsumablesForVisits = new HashSet<SpentConsumablesForVisit>();
        }

        public int ClientVisitId { get; set; }
        public DateTime VisitDate { get; set; }
        public int RecordId { get; set; }
        public int VisitTypeId { get; set; }
        public virtual Record Record { get; set; }
        public virtual VisitType VisitType { get; set; }
        public virtual ICollection<SpentConsumablesForVisit> SpentConsumablesForVisits { get; set; }
    }
}
