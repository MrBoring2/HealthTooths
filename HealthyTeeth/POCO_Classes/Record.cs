using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyTeeth.POCO_Classes
{
    public class Record : BaseModel
    {
        [JsonPropertyName("recordId")]
        public int RecordId { get; set; }
        [JsonPropertyName("clientId")]
        public int ClientId { get; set; }
        [JsonPropertyName("doctorId")]
        public int DoctorId { get; set; }
        [JsonPropertyName("recordDate")]
        public DateTime RecordDate { get; set; }
        [JsonPropertyName("doctor")]
        public virtual Doctor Doctor { get; set; }

        public string ClientFullName => Client.ClientFullName;
        public string Date => RecordDate.ToString("dd.MM.yyyy HH:mm");
        public virtual Client Client { get; set; }
        //public virtual ClientsVisit ClientsVisit { get; set; }
    }
}
