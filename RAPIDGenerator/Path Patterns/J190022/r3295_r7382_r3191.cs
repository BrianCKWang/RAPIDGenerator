using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAPIDGenerator.RAPID_Data_Types;
using RAPIDGenerator.Factory_Data_Types.Product;

namespace RAPIDGenerator.Path_Patterns.J190022
{
    
    class r3295_r7382_r3191 : r3295_r7382_r3191_Settings, IRAPIDPath
    {

        public BreadStick BreadStick;
        public List<RobTarget> outputPath;

        public r3295_r7382_r3191(r3295_r7382_r3191_Settings settings)
        {
            LengthCount = settings.LengthCount;
            WidthCount = settings.WidthCount;
            LengthGap = settings.LengthGap;
            WidthGap = settings.WidthGap;
            StartPoint = settings.StartPoint;
            CutDepth = settings.CutDepth;
            Offset_X = settings.Offset_X;
            Offset_Y = settings.Offset_Y;
            ApproachHeight = settings.ApproachHeight;

            outputPath = GeneratePath();
        }

        private List<RobTarget> GeneratePath()
        {
            List<RobTarget> tempList = new List<RobTarget>();

            tempList.Add(new RobTarget());
            

            return tempList;
        }

        public List<RobTarget> GetPath()
        {
            return outputPath;
        }
    }
}
