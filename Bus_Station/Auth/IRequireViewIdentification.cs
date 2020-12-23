using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Station.Auth
{
    public interface IRequireViewIdentification
    {
        Guid ViewID { get; }
    }
}
