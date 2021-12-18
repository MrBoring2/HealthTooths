using System;
using System.Collections.Generic;

#nullable disable

namespace HealthyTeethAPI.Data
{
    public partial class Client
    {
        public Client()
        {
            Records = new HashSet<Record>();
        }

        public int ClientId { get; set; }
        public string ClientFullName { get; set; }
        public string ClientGender { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
    }
}
