using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABI.Robotics.RAPIDGenerator_Engine.Writer;
using ABI.Robotics.RAPIDGenerator_Engine.Path_Patterns.J190022;

namespace ABI.Robotics.RAPIDGenerator_Engine
{
    public class RAPIDGeneratorServer : INotifyPropertyChanged
    {
        J190022_SKU.r3295_r7382_r3191_Settings settings1 = new Path_Patterns.J190022.J190022_SKU.r3295_r7382_r3191_Settings();
        
        J190022_SKU r3295_3X7_Setting1;
        private RAPIDWriter RAPIDWriter;
        public RAPIDGeneratorServer()
        {
            settings1.LengthCount = 3;
            settings1.WidthCount = 3;
            settings1.LengthGap = 8.5;
            settings1.WidthGap = 3;
            settings1.StartPoint = new ABB_RAPID_Library.RAPID_Data_Types.Pos(678, 110, 0);
            settings1.CutDepth = 2;
            settings1.Offset_X = 30;
            settings1.Offset_Y = 0;
            settings1.ApproachHeight = 30;
            settings1.FirstRowLowToHigh = true;
            r3295_3X7_Setting1  = new J190022_SKU(settings1);
            RAPIDWriter = new RAPIDWriter(@"C:\Users\kai23\Projects\ABI\Robotics\RAPIDGenerator\Files", "RAPIDFile.mod", r3295_3X7_Setting1.ToStringList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GenerateRAPID()
        {
           RAPIDWriter.writeToFile();
        }
    }
}
