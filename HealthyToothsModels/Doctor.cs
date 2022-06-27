using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyToothsModels
{
    [Table("Doctor")]
    public class Doctor : Employee
    {
     
        public int CabinetId { get; set; }

        public Cabinet Cabinet { get; set; }

        public virtual ICollection<Record> Records { get; set; }
      
        public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
    }
}
