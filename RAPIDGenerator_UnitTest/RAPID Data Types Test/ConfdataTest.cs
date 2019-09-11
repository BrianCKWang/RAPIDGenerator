using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABB_RAPID_Library.RAPID_Data_Types;

namespace RAPIDGenerator_UnitTest.RAPID_Data_Types_Test
{
    [TestClass]
    public class ConfdataTest
    {
        [TestMethod]
        public void TestConfdataConstructor()
        {
            Confdata confdata = new Confdata(1.0, 2.0, 3.0, 4.0);

            var expt_confdata_cf1 = 1.0;
            var expt_confdata_cf4 = 2.0;
            var expt_confdata_cf6 = 3.0;
            var expt_confdata_cfx = 4.0;

            Assert.AreEqual(expt_confdata_cf1, confdata.cf1);
            Assert.AreEqual(expt_confdata_cf4, confdata.cf4);
            Assert.AreEqual(expt_confdata_cf6, confdata.cf6);
            Assert.AreEqual(expt_confdata_cfx, confdata.cfx);
            Assert.IsInstanceOfType(confdata, typeof(Confdata));
        }
    }
}
