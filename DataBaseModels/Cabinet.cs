
using System;
using System.Collections.Generic;

#nullable disable

namespace DataBaseModels
{
    public partial class Cabinet
    {
        public int CabinetId { get; set; }
        public int CabinetNumber { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
