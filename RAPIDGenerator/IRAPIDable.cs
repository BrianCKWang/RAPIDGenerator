using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAPIDGenerator.RAPID_Data_Types;

namespace RAPIDGenerator
{
    interface IRAPIDable
    {
        List<RobTarget> GetPath();

    }
}
