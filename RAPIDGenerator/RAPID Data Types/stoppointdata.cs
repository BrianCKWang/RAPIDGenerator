using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPIDGenerator.RAPID_Data_Types
{
    public class Stoppointdata
    {
        public enum stoppointTypeEnum
        {
            inpos,
            stoptime,
            followtime
        }

        stoppointTypeEnum stoppointType;
        public Inpos Inpos;
        public double StopTime;
        public double FollowTime;
        public string Signal;
        public double Relation;
        public double CheckValue;

        public Stoppointdata(stoppointTypeEnum stoppointType, Inpos inpos, double stopTime, double followTime, string signal, double relation, double checkValue)
        {
            this.stoppointType = stoppointType;
            Inpos = inpos;
            StopTime = stopTime;
            FollowTime = followTime;
            Signal = signal;
            Relation = relation;
            CheckValue = checkValue;
        }
    }
}
