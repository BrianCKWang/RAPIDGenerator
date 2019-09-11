using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABB_RAPID_Library.RAPID_Data_Types;

namespace RAPIDGenerator_UnitTest
{
    [TestClass]
    public class RobTargetTest
    {
        [TestMethod]
        public void TestRobtargetConstructor()
        {
            RobTarget robTarget = new RobTarget("Target_11", 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0);

            var expt_pos_x = 1.0;
            var expt_pos_y = 2.0;
            var expt_pos_z = 3.0;
            var expt_orient_q1 = 4.0;
            var expt_orient_q2 = 5.0;
            var expt_orient_q3 = 6.0;
            var expt_orient_q4 = 7.0;

            Assert.AreEqual(expt_pos_x, robTarget.pos.x);
            Assert.AreEqual(expt_pos_y, robTarget.pos.y);
            Assert.AreEqual(expt_pos_z, robTarget.pos.z);
            Assert.AreEqual(expt_orient_q1, robTarget.orient.q1);
            Assert.AreEqual(expt_orient_q2, robTarget.orient.q2);
            Assert.AreEqual(expt_orient_q3, robTarget.orient.q3);
            Assert.AreEqual(expt_orient_q4, robTarget.orient.q4);
            Assert.IsInstanceOfType(robTarget, typeof(RobTarget));
        }
    }
}
