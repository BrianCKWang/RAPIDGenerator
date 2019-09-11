using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB_RAPID_Library.RAPID_Data_Types
{
    class Speeddata_Predefined
    {
        enum speedEnum
        {
            v5 = 5,
            v10 = 10,
            v20 = 20,
            v30 = 30,
            v40 = 40,
            v50 = 50,
            v60 = 60,
            v80 = 80,
            v100 = 100,
            v150 = 150,
            v200 = 200,
            v300 = 300,
            v400 = 400,
            v500 = 500,
            v600 = 600,
            v800 = 800,
            v1000 = 1000,
            v1500 = 1500,
            v2000 = 2000,
            v2500 = 2500,
            v3000 = 3000,
            v4000 = 4000,
            v5000 = 5000,
            v6000 = 6000,
            v7000 = 7000
        }
        Dictionary<speedEnum, Speeddata> speed;
        Dictionary<speedEnum, string> speed_str;

        public Speeddata_Predefined()
        {
            speed.Add(speedEnum.v5, new Speeddata(5, 500, 5000, 1000));
            speed.Add(speedEnum.v10, new Speeddata(10, 500, 5000, 1000));
            speed.Add(speedEnum.v20, new Speeddata(20, 500, 5000, 1000));
            speed.Add(speedEnum.v30, new Speeddata(30, 500, 5000, 1000));
            speed.Add(speedEnum.v40, new Speeddata(40, 500, 5000, 1000));
            speed.Add(speedEnum.v50, new Speeddata(50, 500, 5000, 1000));
            speed.Add(speedEnum.v60, new Speeddata(60, 500, 5000, 1000));
            speed.Add(speedEnum.v80, new Speeddata(80, 500, 5000, 1000));
            speed.Add(speedEnum.v100, new Speeddata(100, 500, 5000, 1000));
            speed.Add(speedEnum.v150, new Speeddata(150, 500, 5000, 1000));
            speed.Add(speedEnum.v200, new Speeddata(200, 500, 5000, 1000));
            speed.Add(speedEnum.v300, new Speeddata(300, 500, 5000, 1000));
            speed.Add(speedEnum.v400, new Speeddata(400, 500, 5000, 1000));
            speed.Add(speedEnum.v500, new Speeddata(500, 500, 5000, 1000));
            speed.Add(speedEnum.v600, new Speeddata(600, 500, 5000, 1000));
            speed.Add(speedEnum.v800, new Speeddata(800, 500, 5000, 1000));
            speed.Add(speedEnum.v1000, new Speeddata(1000, 500, 5000, 1000));
            speed.Add(speedEnum.v1500, new Speeddata(1500, 500, 5000, 1000));
            speed.Add(speedEnum.v2000, new Speeddata(2000, 500, 5000, 1000));
            speed.Add(speedEnum.v2500, new Speeddata(2500, 500, 5000, 1000));
            speed.Add(speedEnum.v3000, new Speeddata(3000, 500, 5000, 1000));
            speed.Add(speedEnum.v4000, new Speeddata(4000, 500, 5000, 1000));
            speed.Add(speedEnum.v5000, new Speeddata(5000, 500, 5000, 1000));
            speed.Add(speedEnum.v6000, new Speeddata(6000, 500, 5000, 1000));
            speed.Add(speedEnum.v7000, new Speeddata(7000, 500, 5000, 1000));

            speed_str.Add(speedEnum.v5,   "v5");
            speed_str.Add(speedEnum.v10,  "v10");
            speed_str.Add(speedEnum.v20,  "v20");
            speed_str.Add(speedEnum.v30,  "v30");
            speed_str.Add(speedEnum.v40,  "v40");
            speed_str.Add(speedEnum.v50,  "v50");
            speed_str.Add(speedEnum.v60,  "v60");
            speed_str.Add(speedEnum.v80,  "v80");
            speed_str.Add(speedEnum.v100, "v100");
            speed_str.Add(speedEnum.v150, "v150");
            speed_str.Add(speedEnum.v200, "v200");
            speed_str.Add(speedEnum.v300, "v300");
            speed_str.Add(speedEnum.v400, "v400");
            speed_str.Add(speedEnum.v500, "v500");
            speed_str.Add(speedEnum.v600, "v600");
            speed_str.Add(speedEnum.v800, "v800");
            speed_str.Add(speedEnum.v1000,"v1000");
            speed_str.Add(speedEnum.v1500,"v1500");
            speed_str.Add(speedEnum.v2000,"v2000");
            speed_str.Add(speedEnum.v2500,"v2500");
            speed_str.Add(speedEnum.v3000,"v3000");
            speed_str.Add(speedEnum.v4000,"v4000");
            speed_str.Add(speedEnum.v5000,"v5000");
            speed_str.Add(speedEnum.v6000,"v6000");
            speed_str.Add(speedEnum.v7000,"v7000");
        }
    }
}
