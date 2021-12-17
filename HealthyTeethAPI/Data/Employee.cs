using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyTeethAPI.Data
{
    public partial class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
    }
}
