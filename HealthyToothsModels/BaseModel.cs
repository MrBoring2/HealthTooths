using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyToothsModels
{
    public class BaseModel
    {
        public object GetProperty(string property)
        {
            return GetType().GetProperty(property).GetValue(this, null);
        }
    }
}
