using HealthyTeethAPI.Data;
using System;
using System.Collections.Generic;

#nullable disable

namespace HealthyTeethAPI.Data
{
    public partial class Record
    {
        public int RecordId { get; set; }
        public int ClientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime RecordDate { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Client Client { get; set; }
    }
}
