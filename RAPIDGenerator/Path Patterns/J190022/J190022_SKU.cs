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
            List<List<Pos>> FullCenterPosList = new List<List<Pos>>();

            List<J190022_BreadStick_SpacingCut> FullPosList = new List<J190022_BreadStick_SpacingCut>();
            List<RobTarget> FullRobTargetList = new List<RobTarget>();
            List<RAPIDCode> OutputList = new List<RAPIDCode>();

            int numberOfColumn = 4;
            const int numberOfRow = 3;
            

            // Generate all center pos list
            for(int i = 0; i < numberOfColumn * numberOfRow; ++i)
            {
                TempCenterPosList.Add(new Pos(
                    settings.StartPoint.x + Math.Truncate((double)i / numberOfColumn) * settings.LengthGap,
                    settings.StartPoint.y + i % numberOfColumn * settings.LengthGap,
                    0));

                if ((i + 1) % numberOfColumn == 0)
                {
                    FullCenterPosList.Add(TempCenterPosList);
                    if (i > 0 && i < (numberOfColumn * numberOfRow - 1))
                    {
                        TempCenterPosList = new List<Pos>();
                    }
                }
            }

            // Optimize path by flipping side for alternating rows
            for (int i = 0; i < FullCenterPosList.Count; ++i)
            {
                if (settings.FirstRowLowToHigh)
                {
                    if ((i % 2) == 1)
                    {
                        FullCenterPosList[i] = FullCenterPosList[i].OrderByDescending(e => e.y).ToList();
                    }
                }
                else
                {
                    if ((i % 2) == 0)
                    {
                        FullCenterPosList[i] = FullCenterPosList[i].OrderByDescending(e => e.y).ToList();
                    }
                }
            }

            // Generate full pos list for all cuts on each product
            foreach (List<Pos> ListPosVarb in FullCenterPosList)
            {
                //List of Pos in each row
                foreach (Pos Varb in ListPosVarb)
                {
                    FullPosList.Add(new J190022_BreadStick_SpacingCut(Varb, 3, 25.4, false));
                }
            }

            for (int i = 1; i < FullPosList.Count(); ++i)
            {
                if(needToChangeCutOrder(FullPosList[i - 1], FullPosList[i]))
                {
                    FullPosList[i].LowToHigh = !FullPosList[i].LowToHigh;
                }
            }

            // Convert all pos into RobTargets
            int RobTargetIndex = 1;
            Orient orient = new Orient(-0.000000015, 0.923879533, -0.382683432, 0.000000035);
            foreach(J190022_BreadStick_SpacingCut Varb in FullPosList)
            {
                List<Pos> tempPos = Varb.CutPos;
                foreach(Pos pos in tempPos)
                {
                    FullRobTargetList.Add(new RobTarget("Target_" + RobTargetIndex.ToString() + "0", pos, orient));

                    RobTargetIndex++;
                }
            }

            #region RobTarget Example
            /*
                CONST robtarget Target_100:=[[678,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_110:=[[628,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_120:=[[578,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_130:=[[578,1034,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_140:=[[628,1032,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_150:=[[678,1033,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_160:=[[678, 957,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_170:=[[628, 953,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_180:=[[578, 951,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]]; 
    
                CONST robtarget Target_190:=[[458, 957,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_200:=[[408, 953,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_210:=[[358, 951,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_220:=[[358,1034,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_230:=[[408,1032,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_240:=[[458,1033,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_250:=[[458,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_260:=[[408,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_270:=[[358,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
    
                CONST robtarget Target_280:=[[238,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
                CONST robtarget Target_290:=[[188,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_300:=[[138,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_310:=[[138,1034,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_320:=[[188,1032,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_330:=[[228,1033,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_340:=[[228, 957,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_350:=[[188, 953,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_360:=[[138, 951,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
   
    
                CONST robtarget Target_100_2:=[[678,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_110_2:=[[653,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_120_2:=[[628,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_130_2:=[[628,1034,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_140_2:=[[653,1032,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_150_2:=[[678,1033,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_160_2:=[[678, 957,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_170_2:=[[653, 953,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_180_2:=[[628, 951,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
    
                CONST robtarget Target_190_2:=[[458, 957,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_200_2:=[[433, 953,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_210_2:=[[408, 951,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_220_2:=[[408,1034,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_230_2:=[[433,1032,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_240_2:=[[458,1033,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_250_2:=[[458,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_260_2:=[[433,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_270_2:=[[408,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];	
    
                CONST robtarget Target_280_2:=[[238,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
                CONST robtarget Target_290_2:=[[213,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_300_2:=[[188,1109,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_310_2:=[[188,1034,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_320_2:=[[213,1032,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_330_2:=[[238,1033,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_340_2:=[[238, 957,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_350_2:=[[213, 953,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
	            CONST robtarget Target_360_2:=[[188, 951,32],[-0.000000015,0.923879533,-0.382683432,0.000000035],[0,0,0,0],[9E+09,9E+09,9E+09,9E+09,9E+09,0]];
             */
            #endregion
            
            

            return FullRobTargetList;
        }

        private void GenerateRAPIDCode()
        {
            RAPIDCode = new List<RAPIDCode>();
            RAPIDCode.Add(new RAPIDCode("MODULE Module1 "));
            RAPIDCode.Add(new RAPIDCode("	PERS tooldata tPlungeDukane:=[TRUE,[[0,-0.14,318.999],[1,0,0,0]],[2.006,[0,-1.643,143.868],[1,0,0,0],0,0,0]]; "));

            foreach (RobTarget varb in RobTargets)
            {
                RAPIDCode.Add(new RAPIDCode(varb.GetRobTargetString()));
            }

            

            RAPIDCode.Add(new RAPIDCode("VAR num recipe := 2;    !1: r3295                                                            "));
            RAPIDCode.Add(new RAPIDCode("                        !2: r7382                                                            "));
            RAPIDCode.Add(new RAPIDCode("VAR num X_Offset := "+ settings.Offset_X.ToString() + ";                                                             "));
            RAPIDCode.Add(new RAPIDCode("VAR num Z_CutDepth := -"+ settings.CutDepth.ToString()+ ";                                                            "));
            RAPIDCode.Add(new RAPIDCode("                                                                                                              "));
            RAPIDCode.Add(new RAPIDCode("PROC main()                                                           "));
            RAPIDCode.Add(new RAPIDCode("    ActUnit CNV1;                                                           "));
            RAPIDCode.Add(new RAPIDCode("    ConfL \\off;                                                           "));
            RAPIDCode.Add(new RAPIDCode("    WHILE TRUE DO                                                           "));
            RAPIDCode.Add(new RAPIDCode("        WaitWObj wobj_cnv1;                                                           "));
            RAPIDCode.Add(new RAPIDCode("                                                           "));
            RAPIDCode.Add(new RAPIDCode("            Path_r3295;                                                           "));
            RAPIDCode.Add(new RAPIDCode("                                                           "));
            RAPIDCode.Add(new RAPIDCode("    WaitRob \\InPos;                                                           "));
            RAPIDCode.Add(new RAPIDCode("    DropWObj wobj_cnv1;                                                           "));
            RAPIDCode.Add(new RAPIDCode("    WaitTime 0.2;                                                           "));
            RAPIDCode.Add(new RAPIDCode("    ENDWHILE                                                                                                              "));
            RAPIDCode.Add(new RAPIDCode("ENDPROC                                                                                                              "));
            RAPIDCode.Add(new RAPIDCode("                                                                                                              "));
            RAPIDCode.Add(new RAPIDCode("PROC Path_r3295()                                                                                                              "));
            foreach (RobTarget varb in RobTargets)
            {
                RAPIDCode.Add(new RAPIDCode("MoveL RelTool("+ varb.Name+ ", X_Offset, 0, -30),v7000, z5, tPlungeDukane\\WObj:= wobj_cnv1; MoveL RelTool(" + varb.Name + ", X_Offset, 0, -Z_CutDepth),v7000,z1,tPlungeDukane\\WObj:= wobj_cnv1; MoveL RelTool(" + varb.Name + ", X_Offset, 0, -30),v7000, z5, tPlungeDukane\\WObj:= wobj_cnv1;"));

            }
            RAPIDCode.Add(new RAPIDCode("ENDPROC                                                                                                              "));
            
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
