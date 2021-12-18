using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyTeeth.POCO_Classes
{
    public class Doctor : Employee
    {
        [JsonPropertyName("cabinetId")]
        public int CabinetId { get; set; }
        [JsonPropertyName("cabinet")]
        public Cabinet Cabinet { get; set; }
        [JsonPropertyName("records")]
        public virtual ICollection<Record> Records { get; set; }
        //public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
    }
}
