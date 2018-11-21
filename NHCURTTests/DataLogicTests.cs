using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHCURT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCURT.Tests
{
    [TestClass()]
    public class DataLogicTests
    {
        [TestMethod()]
        public void QueryTest()
        {
            var dal = new DataLogic<Manage_Type>();
            var ss = dal.Query();
            ss = ss.Where(x => x.TypeName.Length > 3);

            Assert.IsNull(ss);

        }

        [TestMethod()]
        public void RemoveTest()
        {
            var dal = new DataLogic<Manage_Type>();
            var model = dal.Query(x => x.Path == "jkjk").First();
            dal.Remove(model);
            var res = dal.SaveChange();
            Assert.IsTrue(res.Key, res.Value);
        }
        DataLogic<Manage_Type> dal = new DataLogic<Manage_Type>();
        [TestMethod()]
        public void AddTest()
        {
            dal.Add(new Manage_Type() { Path = "jkjk" });
            var res = dal.SaveChange();
            Assert.IsTrue(res.Key, res.Value);
        }
    }
}