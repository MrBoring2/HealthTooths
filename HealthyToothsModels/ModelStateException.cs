using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthyToothsModels
{
    public class ModelStateException
    {

        public string Exception { get; set; }
  
        public string ErrorMessage { get; set; }
    }
}
