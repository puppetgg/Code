using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApmServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmServices.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void TestTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestTest1()
        {
            Class1 ca = new Class1();
            var res = ca.Test();
            Assert.AreEqual(true, res);
        }
    }
}