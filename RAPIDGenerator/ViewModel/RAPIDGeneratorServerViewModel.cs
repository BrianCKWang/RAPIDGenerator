using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPIDGenerator.ViewModel
{
    public class RAPIDGeneratorServerViewModel
    {
        public RAPIDGeneratorServer RAPIDGeneratorServer { get; set; }

        public RAPIDGeneratorServerViewModel()
        {
            RAPIDGeneratorServer = new RAPIDGeneratorServer();
        }

        public void GenerateRAPID()
        {
            RAPIDGeneratorServer.GenerateRAPID();
        }
    }

            

}
