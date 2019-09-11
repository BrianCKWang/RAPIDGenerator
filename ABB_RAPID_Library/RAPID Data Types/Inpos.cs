using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB_RAPID_Library.RAPID_Data_Types
{
    public class Inpos
    {
        public double position;
        public double speed;
        public double mintime;
        public double maxtime;

        public Inpos(double position, double speed, double mintime, double maxtime)
        {
            this.position = position;
            this.speed = speed;
            this.mintime = mintime;
            this.maxtime = maxtime;
        }
    }
}
