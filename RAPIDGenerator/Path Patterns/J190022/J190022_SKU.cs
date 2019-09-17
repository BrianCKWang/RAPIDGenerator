using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ABB_RAPID_Library.RAPID_Data_Types;
using ABI.Robotics.RAPIDGenerator_Engine.Interface;
using ABI.Robotics.RAPIDGenerator_Engine.Factory_Data_Types.Product;
using ABI.Robotics.RAPIDGenerator_Engine.RAPID_Data_Types;


namespace ABI.Robotics.RAPIDGenerator_Engine.Path_Patterns.J190022
{

    [Description("SKUs for J&J")]
    public class J190022_SKU : IRAPIDReader
    {
        [Description("Setting class for r3295_r7382_r3191.")]
        public class r3295_r7382_r3191_Settings
        {
            public string PathName;
            public int LengthCount;
            public int WidthCount;
            public double LengthGap;
            public double WidthGap;
            public Pos StartPoint;
            public double CutDepth;
            public double Offset_X;
            public double Offset_Y;
            public double ApproachHeight;
            public bool FirstRowLowToHigh;
            public r3295_r7382_r3191_Settings()
            {
                PathName = "";
                LengthCount = 0;
                WidthCount = 0;
                LengthGap = 0;
                WidthGap = 0;
                StartPoint = new Pos(0,0,0);
                CutDepth = 0;
                Offset_X = 0;
                Offset_Y = 0;
                ApproachHeight = 0;
                FirstRowLowToHigh = true;
            }

        }

        private r3295_r7382_r3191_Settings settings;
        public List<RobTarget> RobTargets;
        public List<RAPIDCode> RAPIDCode;
        

        public J190022_SKU(r3295_r7382_r3191_Settings settings)
        {
            if(settings != null)// Valid settings object received
            {
                this.settings = settings;
            }
            else// Invalid settings object received
            {
                this.settings = new r3295_r7382_r3191_Settings();
            }

            RobTargets = GeneratePathRobTargets();
            GenerateRAPIDCode();
        }

        private List<RobTarget> GeneratePathRobTargets()
        {
            List<Pos> TempCenterPosList = new List<Pos>();
            List<List<Pos>> CenterPosList = new List<List<Pos>>();
            List<J190022_BreadStick_SpacingCut> PosWithAllCutsList = new List<J190022_BreadStick_SpacingCut>();
            List<RobTarget> AllCutsRobTargetList = new List<RobTarget>();
            List<RAPIDCode> OutputList = new List<RAPIDCode>();

            int numberOfColumn = settings.WidthCount;
            int numberOfRow = settings.LengthCount;

            #region Generate all center pos list for each product, clear list before starting next row
            for (int i = 0; i < numberOfColumn * numberOfRow; ++i)
            {
                TempCenterPosList.Add(new Pos(
                    settings.StartPoint.x + Math.Truncate((double)i / numberOfColumn) * settings.LengthGap,
                    settings.StartPoint.y + i % numberOfColumn * settings.LengthGap,
                    0));

                if ((i + 1) % numberOfColumn == 0)
                {
                    CenterPosList.Add(TempCenterPosList);
                    if (i > 0 && i < (numberOfColumn * numberOfRow - 1))
                    {
                        TempCenterPosList = new List<Pos>();
                    }
                }
            }
            #endregion

            #region Optimize path by flipping side for alternating rows
            for (int i = 0; i < CenterPosList.Count; ++i)
            {
                if (settings.FirstRowLowToHigh)
                {
                    if ((i % 2) == 1)
                    {
                        CenterPosList[i] = CenterPosList[i].OrderByDescending(e => e.y).ToList();
                    }
                }
                else
                {
                    if ((i % 2) == 0)
                    {
                        CenterPosList[i] = CenterPosList[i].OrderByDescending(e => e.y).ToList();
                    }
                }
            }
            #endregion

            #region Generate full pos list for all cuts on each product
            foreach (List<Pos> ListPosVarb in CenterPosList)
            {
                //List of Pos in each row
                foreach (Pos Varb in ListPosVarb)
                {
                    PosWithAllCutsList.Add(new J190022_BreadStick_SpacingCut(Varb, 3, 25.4, false));
                }
            }
            #endregion

            #region Flip in-product cut order by finding shorter path
            for (int i = 1; i < PosWithAllCutsList.Count(); ++i)
            {
                if(needToChangeCutOrder(PosWithAllCutsList[i - 1], PosWithAllCutsList[i]))
                {
                    PosWithAllCutsList[i].LowToHigh = !PosWithAllCutsList[i].LowToHigh;
                }
            }
            #endregion

            #region Convert all pos into RobTargets
            int RobTargetIndex = 1;
            Orient orient = new Orient(-0.000000015, 0.923879533, -0.382683432, 0.000000035);
            foreach(J190022_BreadStick_SpacingCut Varb in PosWithAllCutsList)
            {
                List<Pos> tempPos = Varb.CutPos;
                foreach(Pos pos in tempPos)
                {
                    AllCutsRobTargetList.Add(new RobTarget("Target_" + RobTargetIndex.ToString() + "0", pos, orient));

                    RobTargetIndex++;
                }
            }
            #endregion

            return AllCutsRobTargetList;
        }

        private void GenerateRAPIDCode()
        {
            RAPIDCode = new List<RAPIDCode>();
            RAPIDCode.Add(new RAPIDCode("MODULE Module1 "));
            RAPIDCode.Add(new RAPIDCode("	PERS tooldata tPlungeDukane:=[TRUE,[[0,-0.14,318.999],[1,0,0,0]],[2.006,[0,-1.643,143.868],[1,0,0,0],0,0,0]];"));
            RAPIDCode.Add(new RAPIDCode(""));

            foreach (RobTarget varb in RobTargets)
            {
                RAPIDCode.Add(new RAPIDCode("   " + varb.GetRobTargetString()));
            }

            RAPIDCode.Add(new RAPIDCode("   VAR num recipe := 2;    !1: r3295"));
            RAPIDCode.Add(new RAPIDCode("                           !2: r7382"));
            RAPIDCode.Add(new RAPIDCode("   VAR num X_Offset := "+ settings.Offset_X.ToString() + ";"));
            RAPIDCode.Add(new RAPIDCode("   VAR num Y_Offset := " + settings.Offset_Y.ToString() + ";"));
            RAPIDCode.Add(new RAPIDCode("   VAR num Z_CutDepth := -"+ settings.CutDepth.ToString()+ ";"));
            RAPIDCode.Add(new RAPIDCode("   VAR num Z_ApproachHeight := -" + settings.ApproachHeight.ToString() + ";"));
            RAPIDCode.Add(new RAPIDCode(""));
            RAPIDCode.Add(new RAPIDCode("   PROC main()"));
            RAPIDCode.Add(new RAPIDCode("       ActUnit CNV1;"));
            RAPIDCode.Add(new RAPIDCode("       ConfL \\off;"));
            RAPIDCode.Add(new RAPIDCode("       WHILE TRUE DO"));
            RAPIDCode.Add(new RAPIDCode("           WaitWObj wobj_cnv1;"));
            RAPIDCode.Add(new RAPIDCode(""));
            RAPIDCode.Add(new RAPIDCode("           Path_r3295;"));
            RAPIDCode.Add(new RAPIDCode(""));
            RAPIDCode.Add(new RAPIDCode("       WaitRob \\InPos;"));
            RAPIDCode.Add(new RAPIDCode("       DropWObj wobj_cnv1;"));
            RAPIDCode.Add(new RAPIDCode("       WaitTime 0.2;"));
            RAPIDCode.Add(new RAPIDCode("       ENDWHILE"));
            RAPIDCode.Add(new RAPIDCode("   ENDPROC"));
            RAPIDCode.Add(new RAPIDCode(""));

            RAPIDCode.Add(new RAPIDCode("   PROC Path_r3295()"));
            foreach (RobTarget varb in RobTargets)
            {
                RAPIDCode.Add(new RAPIDCode("       MoveL RelTool("+ varb.Name+ ", X_Offset, Y_Offset, -"+ settings.ApproachHeight.ToString() + "),v7000, z5, tPlungeDukane\\WObj:= wobj_cnv1; MoveL RelTool(" + varb.Name + ", X_Offset, Y_Offset, -Z_CutDepth),v7000,z1,tPlungeDukane\\WObj:= wobj_cnv1; MoveL RelTool(" + varb.Name + ", X_Offset, Y_Offset, -" + settings.ApproachHeight.ToString() + "),v7000, z5, tPlungeDukane\\WObj:= wobj_cnv1;"));
            }
            RAPIDCode.Add(new RAPIDCode("   ENDPROC"));

            RAPIDCode.Add(new RAPIDCode("ENDMODULE"));
        }

        public List<RAPIDCode> ToStringList()
        {
            return RAPIDCode;
        }

        private bool needToChangeCutOrder(J190022_BreadStick_SpacingCut from, J190022_BreadStick_SpacingCut to)
        {
            double DistanceFromFirstToFirst = Math.Pow(from.CutPos.First().x - to.CutPos.First().x, 2) + Math.Pow(from.CutPos.First().y - to.CutPos.First().y, 2);
            double DistanceFromLastToFirst = Math.Pow(from.CutPos.First().x - to.CutPos.Last().x, 2) + Math.Pow(from.CutPos.First().y - to.CutPos.Last().y, 2);

            if(DistanceFromLastToFirst > DistanceFromFirstToFirst)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
