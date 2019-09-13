using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABB_RAPID_Library.RAPID_Data_Types;
using ABI.Robotics.RAPIDGenerator_Engine.Factory_Data_Types.Product;

namespace ABI.Robotics.RAPIDGenerator_Engine.Path_Patterns.J190022
{
    class J190022_BreadStick_SpacingCut : BreadStick
    {
        private int numberOfCut;
        public double CutSpacing_mm;
        private double _CutSpacing_in;
        private Pos centerPos;
        private List<Pos> cutPos;
        private bool lowToHigh;

        public double CutSpacing_in
        {
            get { return CutSpacing_mm / 25.4; }
        }

        public int NumberOfCut
        {
            get => numberOfCut;
            set { numberOfCut = Math.Abs(value); }
        }

        public Pos CenterPos { get => centerPos;

            set
            {
                centerPos = value;
                cutPos = new List<Pos>();
                cutPos = GenerateCutPos();
            }
        }
        public List<Pos> CutPos { get => cutPos; }
        public bool LowToHigh
        {
            get => lowToHigh;
            set
            {
                lowToHigh = value;
                cutPos = new List<Pos>();
                cutPos = GenerateCutPos();
            }
        }

        public J190022_BreadStick_SpacingCut(Pos centerPos, int numberOfCut, double cutSpacing_mm, bool lowToHigh)
        {
            CutSpacing_mm = cutSpacing_mm;
            NumberOfCut = numberOfCut;
            CenterPos = centerPos;
            LowToHigh = lowToHigh;
            cutPos = new List<Pos>();
            cutPos = GenerateCutPos();
        }

        public List<Pos> GenerateCutPos()
        {
            List<Pos> posList = new List<Pos>();

            if(NumberOfCut % 2 == 1)//Odd number of cut, start pos in center
            {
                for(int i = (numberOfCut-1)/2; i >= -(numberOfCut - 1) / 2; --i)
                {
 
                    posList.Add(new Pos(centerPos.x + (LowToHigh?-i:i) * CutSpacing_mm, centerPos.y, centerPos.z));
                }
            }
            else//Even number of cut, start pos in front
            {
                for (int i = 0; i >= -(numberOfCut - 1); --i)
                {
                    if (LowToHigh)
                    {
                        i *= -1;
                    }
                    posList.Add(new Pos(centerPos.x + i * CutSpacing_mm, centerPos.y, centerPos.z));
                }
            }
            return posList;
        }
    }
}
