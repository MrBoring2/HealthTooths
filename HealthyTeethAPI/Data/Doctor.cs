using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyTeethAPI.Data
{
    [Table("Doctor")]
    public class Doctor : Employee
    {
        public int CabinetId { get; set; }
        public Cabinet Cabinet { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
