using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyTeeth.POCO_Classes
{
    public class Employee
    {
        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("passportNumber")]
        public string PassportNumber { get; set; }
        [JsonPropertyName("passportSeries")]
        public string PassportSeries { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("role")]
        public Role Role { get; set; }
    }
}
