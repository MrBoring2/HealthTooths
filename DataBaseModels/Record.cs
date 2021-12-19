
using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseModels
{
    public partial class Record : BaseModel
    {
        public int RecordId { get; set; }
        public int ClientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime RecordDate { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Client Client { get; set; }
        public string ClientFullName => Client.ClientFullName;
        public string Date => RecordDate.ToString("dd.MM.yyyy HH:mm");
    }
}
