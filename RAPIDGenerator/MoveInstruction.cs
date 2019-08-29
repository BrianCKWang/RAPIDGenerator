using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAPIDGenerator.RAPID_Data_Types;

namespace RAPIDGenerator
{
    class MoveInstruction
    {
        /*
        MoveL
        ['\' Conc ', ' ]
        [ToPoint ':='] < expression(IN) of robtarget >
        ['\' ID ':= ' < expression (IN) of identno >] ', '
        [Speed ':='] < expression(IN) of speeddata >
        ['\' V ':= ' < expression (IN) of num > ]
        | ['\' T ':= ' < expression (IN) of num > ] ', '
        [Zone ':='] < expression(IN) of zonedata >
        ['\' Z ':= '< expression (IN) of num > ]
        ['\' Inpos ':= ' < expression (IN) of stoppointdata > ] ', '
        [Tool ':='] < persistent(PERS) of tooldata >
        ['\' WObj ':= ' < persistent (PERS) of wobjdata > ]
        ['\' Corr ]
        ['\' TLoad ':= ' < persistent (PERS) of loaddata > ] ';'
        */

        public enum MoveTypeEnum
        {
            MoveL,
            MoveJ,
            MoveC
        }

        public MoveTypeEnum MoveType;
        public bool isConc;             //['\' Conc ', ' ]

        
        public RobTarget RobTarget;     //[ToPoint ':='] < expression(IN) of robtarget >
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
        public bool hasCorr;            //['\' Corr ]
        public bool hasTload;           //['\' TLoad ':= ' < persistent (PERS) of loaddata > ] ';'
        public string Tload;

        public string RobTargetToString()
        {

            return "";
        }
    }
}
