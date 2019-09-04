using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAPIDGenerator.Path_Patterns;
 

namespace RAPIDGenerator
{
    public class RAPIDGeneratorServer : INotifyPropertyChanged
    {
        Path_Patterns.J190022.r3295_r7382_r3191_Settings settings1 = new Path_Patterns.J190022.r3295_r7382_r3191_Settings(3, 3, 8.5, 3, 0, 2, 0, 0, 30);
        Path_Patterns.J190022.r3295_r7382_r3191 r3295_3X7_Setting1;
        private RAPIDWriter RAPIDWriter;
        public RAPIDGeneratorServer()
        {
            r3295_3X7_Setting1  = new Path_Patterns.J190022.r3295_r7382_r3191(settings1);
            RAPIDWriter = new RAPIDWriter(@"E:\Brian\ABI\RAPIDGenerator", "RAPIDFile.mod", r3295_3X7_Setting1.GetPath());
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
