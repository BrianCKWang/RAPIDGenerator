using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAPIDGenerator.Path_Patterns;

namespace RAPIDGenerator
{
    public class RAPIDGeneratorServer
    {
        Path_Patterns.J190022.r3295_r7382_r3191_Settings settings1 = new Path_Patterns.J190022.r3295_r7382_r3191_Settings(3, 3, 8.5, 3, 0, 2, 0, 0, 30);
        Path_Patterns.J190022.r3295_r7382_r3191 r3295_3X7_Setting1;

        public RAPIDGeneratorServer()
        {
            r3295_3X7_Setting1  = new Path_Patterns.J190022.r3295_r7382_r3191(settings1);
            makeClass();
        }

        private void makeClass()
        {
            
        }
    }
}
