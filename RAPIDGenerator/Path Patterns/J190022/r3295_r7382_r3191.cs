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
            if(settings != null)// Valid settings object received
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
            }
            else// Invalid settings object received
            {
                LengthCount     = 0;
                WidthCount      = 0;
                LengthGap       = 0;
                WidthGap        = 0;
                StartPoint      = 0;
                CutDepth        = 0;
                Offset_X        = 0;
                Offset_Y        = 0;
                ApproachHeight  = 0;
            }
            
            outputPath = GeneratePath();
        }

        private List<RobTarget> GeneratePath()
        {
            List<RobTarget> tempList = new List<RobTarget>();

            tempList.Add(new RobTarget("Target", new Pos(1, 0, 0), new Orient(1, 0, 0, 0)));
            tempList.Add(new RobTarget("Target", new Pos(2, 0, 0), new Orient(0, 2, 0, 0)));
            tempList.Add(new RobTarget("Target", new Pos(3, 0, 0), new Orient(0, 0, 3, 0)));
            tempList.Add(new RobTarget("Target", new Pos(4, 0, 0), new Orient(0, 0, 0, 4)));
            tempList.Add(new RobTarget("Target", new Pos(5, 0, 0), new Orient(5, 0, 0, 0)));

            return tempList;
        }

        public List<RobTarget> GetPath()
        {
            return outputPath;
        }
    }
}
