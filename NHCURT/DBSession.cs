using NHibernate;
using NHibernate.Cfg;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace NHCURT
{
    public class SQLWatcher : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Debug.WriteLine("sql语句:" + sql);
            File.WriteAllText("c:\\work\\sql.txt", sql.ToString());
            return base.OnPrepareStatement(sql);
        }
    }
    public class DBSession
    {

        private static readonly ISession session = new Configuration().Configure().BuildSessionFactory().OpenSession(new SQLWatcher());
        public static ISession GetCurrentDBSession()
        {
            ISession currentSession = CallContext.GetData("session") as ISession;
            if (currentSession == null)
            {
                currentSession = session;
                CallContext.SetData("session", session);
            }
            return currentSession;

        }



    }
}