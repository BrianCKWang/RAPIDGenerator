using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPIDGenerator.RAPID_Data_Types
{
    class Speeddata
    {
        public int v_tcp;
        public int v_ori;
        public int v_leax;
        public int v_reax;

        public Speeddata(int v_tcp, int v_ori, int v_leax, int v_reax)
        {
            this.v_tcp = v_tcp;
            this.v_ori = v_ori;
            this.v_leax = v_leax;
            this.v_reax = v_reax;
        }
    }
}
