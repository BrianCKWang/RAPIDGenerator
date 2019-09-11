using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABB_RAPID_Library.RAPID_Data_Types;

namespace RAPIDGenerator_UnitTest.RAPID_Data_Types_Test
{
    [TestClass]
    public class OrientTest
    {
        [TestMethod]
        public void TestOrientConstructor()
        {
            Orient orient = new Orient(1.0, 2.0, 3.0, 4.0);

            var expt_orient_q1 = 1.0;
            var expt_orient_q2 = 2.0;
            var expt_orient_q3 = 3.0;
            var expt_orient_q4 = 4.0;

            Assert.AreEqual(expt_orient_q1, orient.q1);
            Assert.AreEqual(expt_orient_q2, orient.q2);
            Assert.AreEqual(expt_orient_q3, orient.q3);
            Assert.AreEqual(expt_orient_q4, orient.q4);
            Assert.IsInstanceOfType(orient, typeof(Orient));
        }
    }
}
