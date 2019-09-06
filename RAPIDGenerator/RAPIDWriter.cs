using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RAPIDGenerator.RAPID_Data_Types;

namespace RAPIDGenerator
{
    class RAPIDWriter
    {
        public string FilePath; //"E:\\Brian\\Projects\\Project 11 - Cake Sculptor Software Upgrade\\TestModule_CylindricalMovement.mod"
        public string FileName; //TestModule_CylindricalMovement.mod
        public string FullPath;
        List<RobTarget> RobTargetList;

        public RAPIDWriter(List<RobTarget> robTargetList)
        {
            FullPath = @"E:\Brian\ABI\RAPIDGenerator";
            this.RobTargetList = robTargetList;
        }

        public RAPIDWriter(string fullPath, List<RobTarget> robTargetList)
        {
            this.FullPath = fullPath;
            this.RobTargetList = robTargetList;
        }

        public RAPIDWriter(string filePath, string fileName, List<RobTarget> robTargetList)
        {
            FilePath = filePath;
            FileName = fileName;
            RobTargetList = robTargetList;
        }

        public void writeToFile()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var completePath = Path.Combine(systemPath, "files");

            //string PatternSaveName = "Pattern_Nesting.txt";
            bool fileExist = File.Exists(@FilePath + @"\" + FileName);

            if (fileExist)
            {
                File.Delete(@FilePath + @"\" + FileName);
            }
            using (StreamWriter file = new StreamWriter(@FilePath + @"\" + FileName, true))
            {

                file.WriteLine("MODULE Nesting");

                //foreach (RobTarget varb in RobTargetList)
                //{
                //    //file.WriteLine("CONST robtarget " + varb.Name + "_" + varb. + " := [[" + varb.pos.x + "," + varb.pos.y + "," + varb.pos.z + "]," + varb.Ori + "," + varb.Conf + "," + varb.Ej + "];");
                //    file.WriteLine("CONST robtarget " + varb.Name + "_" + " := [[" + varb.pos.x + "," + varb.pos.y + "," + varb.pos.z + "]," + "[" + varb.orient.q1 + ", " + varb.orient.q2 + ", " + varb.orient.q3 + ", " + varb.orient.q4 + "]" + "];");
                //}

                if(RobTargetList.Count > 0)
                {
                    for (int i = 0; i < RobTargetList.Count; ++i)
                    {
                        file.WriteLine("CONST robtarget " + RobTargetList[i].Name + "_" + ((i + 1) * 10).ToString() + " := [[" + RobTargetList[i].pos.x + "," + RobTargetList[i].pos.y + "," + RobTargetList[i].pos.z + "]," + "[" + RobTargetList[i].orient.q1 + ", " + RobTargetList[i].orient.q2 + ", " + RobTargetList[i].orient.q3 + ", " + RobTargetList[i].orient.q4 + "]" + "];");
                    }
                }
                

                file.WriteLine("PROC NestedShape0()");
                file.WriteLine("var speeddata vCutSpeed;");
                file.WriteLine("vCutSpeed:= GenerateSpeedData(30);");

                //foreach (MoveInstruction varb in _moveInstructionsFullList)
                //{
                //    if (varb.MoveType == "MoveL")
                //    {
                //        MoveL NestedShape_robtarget413,vCutSpeed,z1,tWaterJet\Wobj:=wobjCake;
                //        file.WriteLine(varb.MoveType + " " + varb.Robtarget + "," + varb.CutSpeed + "," + varb.Zone + "," + varb.Tool + ";");
                //    }
                //    else if (varb.MoveType == "TriggL")
                //    {
                //        TriggL NestedShape_robtarget414,vCutSpeed,WaterOff,z0,tWaterJet\Wobj:=wobjCake;
                //        file.WriteLine(varb.MoveType + " " + varb.Robtarget + "," + varb.CutSpeed + "," + varb.Trigger + "," + varb.Zone + "," + varb.Tool + ";");
                //        file.WriteLine("WaitTime 1;");
                //    }
                //    else if (varb.MoveType == "MoveC")
                //    {
                //        TriggL NestedShape_robtarget414,vCutSpeed,WaterOff,z0,tWaterJet\Wobj:=wobjCake;
                //        file.WriteLine(varb.MoveType + " " + varb.Robtarget + "," + varb.Robtarget2 + "," + varb.CutSpeed + "," + varb.Zone + "," + varb.Tool + ";");
                //    }
                //}

                file.WriteLine("EndNestedShape;");
                file.WriteLine("aeKWJ_D_ProgramProgress:= 0;");
                file.WriteLine("SetAO vo_ProgramProgress, (aeKWJ_D_ProgramProgress * 100);");
                file.WriteLine("ENDPROC");
                file.WriteLine("PROC NestingArray()");
                file.WriteLine("NestedShape0;");
                file.WriteLine("ENDPROC");
                file.WriteLine("ENDMODULE");
            }

            Console.WriteLine(completePath);
        }
    }

    
}
