using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataBaseModels
{
    public partial class Client : BaseModel
    {
        public Client()
        {
            Records = new HashSet<Record>();
        }

        public int ClientId { get; set; }
        public string ClientFullName { get; set; }
        public string ClientGender { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ClientDateOfBirth { get; set; }
        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<ClientsVisit> ClientsVisits { get; set; }
        public string Passport => $"{PassportNumber} {PassportSeries}";
        public string PhoneNumberText => PhoneNumber.Length == 11 ? $"+{PhoneNumber[0]} ({PhoneNumber[1]}{PhoneNumber[2]}{PhoneNumber[3]}){PhoneNumber[4]}{PhoneNumber[5]}{PhoneNumber[6]}-{PhoneNumber[7]}{PhoneNumber[8]}{PhoneNumber[9]}{PhoneNumber[10]}" : PhoneNumber;
    }
}
