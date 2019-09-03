using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAPIDGenerator.RAPID_Data_Types;

namespace RAPIDGenerator.RAPID_Instructions.Move_Instructions
{
    class MoveJ : Move
    {
        public MoveJ(bool isConc, RobTarget robTarget, bool hasMultiMoveID, int iD, int speed, bool hasV, int v, bool hasT, int t, int zone, bool hasZ, int z, bool hasInpos, string inpos, string tool, bool hasWobj, string wobj, bool hasTload, string tload)
        {
            this.isConc = isConc;
            ToPoint = robTarget;
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
            this.hasTload = hasTload;
            Tload = tload;
        }

        public MoveJ()
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
            this.hasTload = false;
            Tload = "tload";
        }

        public string RobTargetToString()
        {

            return "";
        }
    }
}
