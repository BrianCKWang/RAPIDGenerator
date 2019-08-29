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
        List<RobTarget> robTargetList;

        public RAPIDWriter(List<RobTarget> RobTargetList)
        {
            robTargetList = RobTargetList;
        }

        private void WriteToFile()
        {
            var systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var completePath = System.IO.Path.Combine(systemPath, "files");

            //E:\Brian\Projects\Project 11 - Cake Sculptor Software Upgrade
            bool fileExist = File.Exists(@FullPath);
            if (fileExist)
            {
                File.Delete(FullPath);
            }
            using (StreamWriter file = new StreamWriter(@FullPath, true))
            {

                file.WriteLine("    PROC OrientZYXTester_AutoGen()");
                file.WriteLine("        ActUnit CNV1;");
                file.WriteLine("        ConfL\\off;");
                file.WriteLine("        DropWObj wobjcnv1;");
                file.WriteLine("        TempRemoveTempCakeWZ;");
                file.WriteLine("        WaitTime 0.1;");
                file.WriteLine("        PulseDO c1RemAllPObj;");
                file.WriteLine("        WaitTime 0.1;");
                file.WriteLine("        MoveL p2018_pHomeReadyPosition, v200, z1, tIcy;");
                file.WriteLine("        SetDO do_Board10_0_CNVForward,1;");
                file.WriteLine("        WaitWobj wobjcnv1\\RelDist:= 1700;");
                file.WriteLine("        !Distance from stop to first tape mark +length of cake and one edge");
                file.WriteLine("        SetDO do_Board10_0_CNVForward,0;");
                file.WriteLine("        WaitTime 1;");
                file.WriteLine("        CurPos:= CRobT(\\Tool:= tIcy);");

                foreach (RobTarget varb in robTargetList)
                {
                    file.WriteLine("        MoveL[[" + txb_refPoint.Text + ".trans.x + (" + varb[0] + "), " + txb_refPoint.Text + ".trans.y + (" + varb[1] + "), " + txb_refPoint.Text + ".trans.z + (" + varb[2] + ")],ori* OrientZyx(" + varb[3] + ", " + varb[4] + ", " + varb[5] + "),conf,ej],V" + txb_V.Text + ",Z" + txb_Z.Text + "," + txb_toolWobj.Text + ";");
                }

                file.WriteLine("        MoveL p2018_pHomeReadyPosition, v200, z1, tIcy;");
                file.WriteLine("        WaitRob\\InPos;");
                file.WriteLine("        stop;");
                file.WriteLine("    ENDPROC");
            }

            //Console.WriteLine(completePath);
        }
    }

    
}
