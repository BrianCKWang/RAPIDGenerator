using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABI.Robotics.RAPIDGenerator_Engine.Path_Patterns.J190022;


namespace RAPIDGenerator_UnitTest.Path_Patterns_Test
{
    [TestClass]
    public class J190022_SKU_Test
    {
        [TestMethod]
        public void TestPosGeneration()
        {
            J190022_SKU.r3295_r7382_r3191_Settings Settings = new J190022_SKU.r3295_r7382_r3191_Settings();
            Settings.LengthCount = 3;
            Settings.WidthCount = 3;
            Settings.LengthGap = 8.5;
            Settings.WidthGap = 3;
            Settings.StartPoint = new ABB_RAPID_Library.RAPID_Data_Types.Pos(678, 110, 0);
            Settings.CutDepth = 2;
            Settings.Offset_X = 0;
            Settings.Offset_Y = 0;
            Settings.ApproachHeight = 30;
            
            J190022_SKU j190022_SKU = new J190022_SKU(Settings);


        }
    }
}
