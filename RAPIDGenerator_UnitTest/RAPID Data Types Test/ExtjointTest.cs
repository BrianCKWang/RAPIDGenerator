using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABB_RAPID_Library.RAPID_Data_Types;

namespace RAPIDGenerator_UnitTest.RAPID_Data_Types_Test
{
    [TestClass]
    public class ExtjointTest
    {
        [TestMethod]
        public void TestExtjointConstructor()
        {
            Extjoint extjoint = new Extjoint(1.0, 2.0, 3.0, 4.0, 5.0);

            var expt_extjoint_eax_a = 1.0;
            var expt_extjoint_eax_b = 2.0;
            var expt_extjoint_eax_c = 3.0;
            var expt_extjoint_eax_d = 4.0;
            var expt_extjoint_eax_f = 5.0;

            Assert.AreEqual(expt_extjoint_eax_a, extjoint.eax_a);
            Assert.AreEqual(expt_extjoint_eax_b, extjoint.eax_b);
            Assert.AreEqual(expt_extjoint_eax_c, extjoint.eax_c);
            Assert.AreEqual(expt_extjoint_eax_d, extjoint.eax_d);
            Assert.AreEqual(expt_extjoint_eax_f, extjoint.eax_f);

            Assert.IsInstanceOfType(extjoint, typeof(Extjoint));
        }
    }
}
