using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAPIDGenerator.RAPID_Data_Types;

namespace RAPIDGenerator.RAPID_Instructions.Move_Instructions
{
    class MoveC : MoveBase, IRAPIDInstruction
    {
        public RobTarget CirPoint;
        public bool hasCorr;

        public MoveC(bool isConc,RobTarget cirPoint, RobTarget toPoint, bool hasMultiMoveID, int iD, int speed, bool hasV, int v, bool hasT, int t, int zone, bool hasZ, int z, bool hasInpos, string inpos, string tool, bool hasWobj, string wobj, bool hasCorr, bool hasTload, string tload)
        {
            this.isConc = isConc;
            CirPoint = cirPoint;
            ToPoint = toPoint;
            this.hasMultiMoveID = hasMultiMoveID;
            ID = iD;
            Speed = speed;
            this.hasV = hasV;
            V = v;
            this.hasT = hasT;
            T = t;
            Zone = zone;
            this.hasZ = hasZ;
            Z = z;
            this.hasInpos = hasInpos;
            Inpos = inpos;
            this.tool = tool;
            this.hasWobj = hasWobj;
            Wobj = wobj;
            this.hasCorr = hasCorr;
            this.hasTload = hasTload;
            Tload = tload;
        }

        public MoveC()
        {
            this.isConc = false;
            ToPoint = new RobTarget();
            this.hasMultiMoveID = false;
            ID = 0;
            Speed = 0;
            this.hasV = false;
            V = 0;
            this.hasT = false;
            T = 0;
            Zone = 0;
            this.hasZ = false;
            Z = 0;
            this.hasInpos = false;
            Inpos = "inpos";
            this.tool = "tool0";
            this.hasWobj = false;
            Wobj = "Wobjcnv1";
            this.hasCorr = false;
            this.hasTload = false;
            Tload = "tload";
        }

        public string RobTargetToString()
        {

            return "";
        }

        public string GenerateInstructionString()
        {
            throw new NotImplementedException();
        }
    }
}
