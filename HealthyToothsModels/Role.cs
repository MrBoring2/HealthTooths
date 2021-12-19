using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyToothsModels
{
    public class Role
    {
        [Key]

        public int RoleId { get; set; }
   
        public string RoleName { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
