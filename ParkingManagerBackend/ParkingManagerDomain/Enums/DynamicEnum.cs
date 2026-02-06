using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerDomain.Enums
{
    public class DynamicEnum<T> where T: Enum
    {
        private T Collection { get; set; }
    }
}
