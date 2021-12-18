using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyTeeth.POCO_Classes
{
    public class Client
    {
        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }
        [JsonPropertyName("clientFullName")]
        public string ClientFullName { get; set; }
        [JsonPropertyName("clientGender")]
        public string ClientGender { get; set; }
        [JsonPropertyName("clientGender")]
        public string PassportNumber { get; set; }
        [JsonPropertyName("passportNumber")]
        public string PassportSeries { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("records")]
        public virtual ICollection<Record> Records { get; set; }
        //public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
    }
}
