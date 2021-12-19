using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseModels
{
    [Table("Administrator")]
    public class Administrator : Employee
    {
        public string PersonalKey { get; set; }
    }
}
