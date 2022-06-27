
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthyToothsModels
{
    public partial class Cabinet
    {
     
        public int CabinetId { get; set; }

        public int CabinetNumber { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
