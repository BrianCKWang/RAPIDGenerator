using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABB_RAPID_Library.RAPID_Data_Types;

namespace ABB_RAPID_Library.RAPID_Instructions.Move_Instructions
{
    class MoveBase
    {
        public bool isConc;             //['\' Conc ', ' ]


        public RobTarget ToPoint;     //[ToPoint ':='] < expression(IN) of robtarget >
        public bool hasMultiMoveID;     //['\' ID ':= ' < expression (IN) of identno >] ', '
        public int ID;

        public int Speed;               //[Speed ':='] < expression(IN) of speeddata >
        public bool hasV;               //['\' V ':= ' < expression (IN) of num > ]
        public int V;
        public bool hasT;               //| ['\' T ':= ' < expression (IN) of num > ] ', '
        public int T;

        public int Zone;                //[Zone ':='] < expression(IN) of zonedata >
        public bool hasZ;               //['\' Z ':= '< expression (IN) of num > ]
        public int Z;
        public bool hasInpos;           //['\' Inpos ':= ' < expression (IN) of stoppointdata > ] ', '
        public string Inpos;

        public string tool;             //[Tool ':='] < persistent(PERS) of tooldata >
        public bool hasWobj;            //['\' WObj ':= ' < persistent (PERS) of wobjdata > ]
        public string Wobj;
        public bool hasTload;           //['\' TLoad ':= ' < persistent (PERS) of loaddata > ] ';'
        public string Tload;
    }
}
