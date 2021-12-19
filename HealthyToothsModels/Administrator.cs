using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyToothsModels
{
    [Table("Administrator")]
    public class Administrator : Employee
    {
    
        public string PersonalKey { get; set; }
    }
}
