using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPIDGenerator.RAPID_Data_Types
{
    public class Pos
    {
        public double x;
        public double y;
        public double z;

        public Pos(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
