using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyTeeth.POCO_Classes
{
    public class Administrator : Employee
    {
        [JsonPropertyName("personalKey")]
        public string PersonalKey { get; set; }
    }
}
