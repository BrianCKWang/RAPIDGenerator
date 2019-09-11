using System;
using System.Collections.Generic;
using System.IO;
using ABI.Robotics.RAPIDGenerator_Engine.RAPID_Data_Types;

namespace ABI.Robotics.RAPIDGenerator_Engine.Writer
{
    class RAPIDWriter 
    {
        public string FilePath; //"E:\\Brian\\Projects\\Project 11 - Cake Sculptor Software Upgrade\\TestModule_CylindricalMovement.mod"
        public string FileName; //TestModule_CylindricalMovement.mod
        public string FullPath;
        List<RAPIDCode> RAPIDLines;

        public RAPIDWriter(string filePath, string fileName, List<RAPIDCode> rAPIDLines)
        {
            FilePath = filePath;
            FileName = fileName;
            RAPIDLines = rAPIDLines;
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
                foreach(RAPIDCode varb in RAPIDLines)
                {
                    file.WriteLine(varb.GetRAPIDLine());
                }
            }

            Console.WriteLine(completePath);
        }
    }

    
}
