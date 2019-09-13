using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABB_RAPID_Library.RAPID_Data_Types;

namespace ABI.Robotics.RAPIDGenerator_Engine.RAPID_Data_Types
{
    public class RAPIDCode
    {
        public string Line;

        public RAPIDCode(string str)
        {
            Line = str;
        }

        public string GetRAPIDLine()
        {
            return Line;
        }
    }
}
