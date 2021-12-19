
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
{
    public partial class Record : BaseModel
    {
   
        public int RecordId { get; set; }

        public int ClientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime RecordDate { get; set; }

        public virtual Doctor Doctor { get; set; }

        public string ClientFullName => Client == null ? "" : Client.ClientFullName;
        public string Date => RecordDate.ToString("dd.MM.yyyy HH:mm");
        public virtual Client Client { get; set; }
    }
}
