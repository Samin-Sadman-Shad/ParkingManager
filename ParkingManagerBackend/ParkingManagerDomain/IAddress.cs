using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerDomain
{
    public interface IAddress
    {
        string Name { get; set; }

        string NameBangla { get; set; }
    }
}
