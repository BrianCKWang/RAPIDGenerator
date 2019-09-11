using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI.Robotics.RAPIDGenerator_Engine.RAPID_Data_Types;

namespace ABI.Robotics.RAPIDGenerator_Engine.Interface
{
    interface IRAPIDReader
    {
        List<RAPIDCode> ToStringList();
    }
}
