using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPIDGenerator.RAPID_Data_Types
{
    public class RobTarget
    {
        
        public class _pos
        {
            public double x;
            public double y;
            public double z;

            public _pos(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
        public class _orient
        {
            public double q1;
            public double q2;
            public double q3;
            public double q4;

            public _orient(double q1, double q2, double q3, double q4)
            {
                this.q1 = q1;
                this.q2 = q2;
                this.q3 = q3;
                this.q4 = q4;
            }
        }
        public class _confdata
        {
            public double cf1;
            public double cf4;
            public double cf6;
            public double cfx;

            public _confdata(double cf1, double cf4, double cf6, double cfx)
            {
                this.cf1 = cf1;
                this.cf4 = cf4;
                this.cf6 = cf6;
                this.cfx = cfx;
            }
        }
        public class _extjoint
        {
            public double eax_a;
            public double eax_b;
            public double eax_c;
            public double eax_d;
            public double eax_f;

            public _extjoint(double eax_a, double eax_b, double eax_c, double eax_d, double eax_f)
            {
                this.eax_a = eax_a;
                this.eax_b = eax_b;
                this.eax_c = eax_c;
                this.eax_d = eax_d;
                this.eax_f = eax_f;
            }
        }

        public string Name;
        public _pos pos;
        public _orient orient;
        public _confdata confdata;
        public _extjoint extjoint;

        public RobTarget()
        {
            Name = "Target_10";
            pos = new _pos(0, 0, 0);
            orient = new _orient(0, 0, 0, 0);
            confdata = new _confdata(0, 0, 0, 0);
            extjoint = new _extjoint(9E+09, 9E+09, 9E+09, 9E+09, 0);
        }
        public RobTarget(string name, double x, double y, double z, double q1, double q2, double q3, double q4)
        {
            Name = name;
            pos = new _pos(x, y, z);
            orient = new _orient(q1, q2, q3, q4);
            confdata = new _confdata(0, 0, 0, 0);
            extjoint = new _extjoint(9E+09, 9E+09, 9E+09, 9E+09, 0);
        }
        public RobTarget(string name, double x, double y, double z, double q1, double q2, double q3, double q4, double cf1, double cf4, double cf6, double cfx )
        {
            Name = name;
            pos = new _pos(x, y, z);
            orient = new _orient(q1, q2, q3, q4);
            confdata = new _confdata(cf1, cf4, cf6, cfx);
            extjoint = new _extjoint(9E+09, 9E+09, 9E+09, 9E+09, 0);
        }
    }
}
