using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RAPIDGenerator.RAPID_Data_Types;

namespace RAPIDGenerator_UnitTest
{
    [TestClass]
    public class PosTest
    {
        [TestMethod]
        public void TestPosConstructor()
        {
            Pos pos = new Pos(1.0, 2.0, 3.0);

            var expt_pos_x = 1.0;
            var expt_pos_y = 2.0;
            var expt_pos_z = 3.0;

            Assert.AreEqual(expt_pos_x, pos.x);
            Assert.AreEqual(expt_pos_y, pos.y);
            Assert.AreEqual(expt_pos_z, pos.z);
            Assert.IsInstanceOfType(pos, typeof(Pos));
        }
    }
}
