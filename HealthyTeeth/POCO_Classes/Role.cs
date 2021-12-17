using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyTeeth.POCO_Classes
{
    public class Role
    {
        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }
        [JsonPropertyName("roleName")]
        public string RoleName { get; set; }
        [JsonPropertyName("employees")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
