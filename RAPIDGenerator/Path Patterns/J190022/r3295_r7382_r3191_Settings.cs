using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPIDGenerator.Path_Patterns.J190022
{
    class r3295_r7382_r3191_Settings
    {
        public int LengthCount;
        public int WidthCount;
        public double LengthGap;
        public double WidthGap;
        public double StartPoint;
        public double CutDepth;
        public double Offset_X;
        public double Offset_Y;
        public double ApproachHeight;

        public r3295_r7382_r3191_Settings()
        {

        }

        public r3295_r7382_r3191_Settings(int lengthCount, int widthCount, double lengthGap, double widthGap, double startPoint, double cutDepth, double offset_X, double offset_Y, double approachHeight)
        {
            LengthCount = lengthCount;
            WidthCount = widthCount;
            LengthGap = lengthGap;
            WidthGap = widthGap;
            StartPoint = startPoint;
            CutDepth = cutDepth;
            Offset_X = offset_X;
            Offset_Y = offset_Y;
            ApproachHeight = approachHeight;
        }
    }
}
