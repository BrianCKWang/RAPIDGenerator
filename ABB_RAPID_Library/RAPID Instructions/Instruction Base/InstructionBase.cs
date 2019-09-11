using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB_RAPID_Library
{
    class InstructionBase
    {
        public enum InstructionEnum
        {
            MoveL,
            MoveJ,
            MoveC
        }

        public InstructionEnum Type
        {
            get; set;
        }

        
    }
}
