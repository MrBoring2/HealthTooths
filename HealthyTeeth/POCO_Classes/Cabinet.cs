using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyTeeth.POCO_Classes
{
    public class Cabinet
    {
        [JsonPropertyName("cabinetId")]
        public int CabinetId { get; set; }
        [JsonPropertyName("cabinetNumber")]
        public int CabinetNumber { get; set; }
        [JsonPropertyName("doctors")]
        public ICollection<Doctor> Doctors { get; set; }
    }
}