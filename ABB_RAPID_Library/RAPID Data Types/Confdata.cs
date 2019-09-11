using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB_RAPID_Library.RAPID_Data_Types
{
    public class Confdata
    {
        public double cf1;
        public double cf4;
        public double cf6;
        public double cfx;

        public Confdata(double cf1, double cf4, double cf6, double cfx)
        {
            this.cf1 = cf1;
            this.cf4 = cf4;
            this.cf6 = cf6;
            this.cfx = cfx;
        }
    }
}
