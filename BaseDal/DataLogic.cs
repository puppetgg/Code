using BaseModel;
using FRD.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BaseDal
{
    public class DataLogic
    {



    }

    public class Manage_TypeDataLogic : RepositoryFactory<Manage_Type>
    {
        //const string constr= ConfigurationManager.GetSection("").ConnectionStrings

        static readonly string con = "server = 10.18.105.189; database=FRDRM_DB;uid=sa;pwd=Password01!";
        public Manage_TypeDataLogic()
        {

        }

        public List<Manage_Type> FindByLambda()
        {
            return Repository(con).FindList();
        }

    }

    //public class BaseDal<T>
    //{
    //    internal ISession session = NHibernateHelper.GetCurrentDbContext();
    //    internal void Save()
    //    {
    //        lock (this)
    //        {
    //            session.BeginTransaction().Commit();
    //        }
    //    }
    //    // 添加
    //    public void Add(T model)

    //    {
    //        session.Save(model);
    //        Save();
    //    }

    //    // 删除         
    //    public void Delete(T model)

    //        => session.Delete(model);


    //    // 更新        
    //    public void Update(T model)

    //        => session.Update(model);


    //    //查询
    //    public List<T> LoadTable(Func<T, bool> whereLambda)
    //    {
    //        lock (session)
    //        {
    //            return session.Query<T>().Where(whereLambda).ToList();
    //        }
    //    }
    //}

    //public class NHibernateHelper
    //{
    //    static readonly ISession staticISession = new Configuration().Configure("hibernate.cfg.xml").BuildSessionFactory().OpenSession();
    //    public static ISession GetCurrentDbContext()
    //    {
    //        ISession dbContext = CallContext.GetData("dbContext") as ISession;
    //        if (dbContext == null)
    //        {
    //            dbContext = staticISession;
    //            CallContext.SetData("dbContext", dbContext);
    //        }
    //        return dbContext;
    //    }
    //}

}
