using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NHibernateTest
{
    [TestFixture]
    public class NHibernateInit
    {
        [Test]
        public void InitTest()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure();
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory()) { }
        }
    }
}