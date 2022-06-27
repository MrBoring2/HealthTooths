using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyToothsModels
{
    public partial class Employee : BaseModel
    {
        [Key]

        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public string Login { get; set; }
 
        public string Password { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
  
        public string PassportNumber { get; set; }

        public string PassportSeries { get; set; }
 
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Passport => $"{PassportNumber} {PassportSeries}";
        public string PhoneNumberText => PhoneNumber.Length == 11 ? $"+{PhoneNumber[0]} ({PhoneNumber[1]}{PhoneNumber[2]}{PhoneNumber[3]}){PhoneNumber[4]}{PhoneNumber[5]}{PhoneNumber[6]}-{PhoneNumber[7]}{PhoneNumber[8]}{PhoneNumber[9]}{PhoneNumber[10]}" : PhoneNumber;
    }
}
