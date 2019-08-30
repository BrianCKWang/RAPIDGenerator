using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPIDGenerator.RAPID_Data_Types
{
    public class RobTarget
    {
        public string Name;
        public Pos pos;
        public Orient orient;
        public Confdata confdata;
        public Extjoint extjoint;

        public RobTarget()
        {
            Name = "Target_10";
            pos = new Pos(0, 0, 0);
            orient = new Orient(0, 0, 0, 0);
            confdata = new Confdata(0, 0, 0, 0);
            extjoint = new Extjoint(9E+09, 9E+09, 9E+09, 9E+09, 0);
        }
        public RobTarget(string name, double x, double y, double z, double q1, double q2, double q3, double q4)
        {
            Name = name;
            pos = new Pos(x, y, z);
            orient = new Orient(q1, q2, q3, q4);
            confdata = new Confdata(0, 0, 0, 0);
            extjoint = new Extjoint(9E+09, 9E+09, 9E+09, 9E+09, 0);
        }
        public RobTarget(string name, double x, double y, double z, double q1, double q2, double q3, double q4, double cf1, double cf4, double cf6, double cfx )
        {
            Name = name;
            pos = new Pos(x, y, z);
            orient = new Orient(q1, q2, q3, q4);
            confdata = new Confdata(cf1, cf4, cf6, cfx);
            extjoint = new Extjoint(9E+09, 9E+09, 9E+09, 9E+09, 0);
        }
    }
}
