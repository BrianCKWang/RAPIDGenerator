using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPIDGenerator.RAPID_Data_Types
{
    public class Extjoint
    {
        public double eax_a;
        public double eax_b;
        public double eax_c;
        public double eax_d;
        public double eax_f;

        public Extjoint(double eax_a, double eax_b, double eax_c, double eax_d, double eax_f)
        {
            this.eax_a = eax_a;
            this.eax_b = eax_b;
            this.eax_c = eax_c;
            this.eax_d = eax_d;
            this.eax_f = eax_f;
        }
    }
}
