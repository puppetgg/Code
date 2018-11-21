using Newtonsoft.Json;
using NHibernate;
using NHibernate.Classic;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NHCURT
{



    //    public static void Main()
    //    {
    //        var dal = new DataLogic();


    //        Console.WriteLine("---------------1----------------------");

    //        var bb = dal.Query<Manage_Type>(x => x.ParentId == "1").Select(x => x.Id);
    //        Console.WriteLine("---------------2----------------------");

    //        var vv = dal.Query<Manage_Type>();
    //        Console.WriteLine("---------------3----------------------");

    //        var cc = vv.Where(x => bb.Contains(x.ParentId)).Select(x => x.Remark).First();
    //        Console.WriteLine("-------------------4------------------");
    //        //bb = bb.Where(x => x.AdminName != null);
    //        //bb = bb.Where(x => x.TypeName.Length > 50);
    //        //var cc = bb.Select(x => x.AdminName != null);
    //        var ss = JsonConvert.SerializeObject(cc);
    //        Console.WriteLine("-------------------------------------");
    //        Console.WriteLine(ss);
    //        Console.Read();
    //    }

    //}


    public class DataLogic
    {
        ISession session = DBSession.GetCurrentDBSession();


        public KeyValuePair<bool, string> SaveChange()
        {
            var tx = session.BeginTransaction();
            try
            {
                tx.Commit();
                return new KeyValuePair<bool, string>(true, "true");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                return new KeyValuePair<bool, string>(false, ex.Message);
            }
        }


        public void Add<T>(T model)

          => session.Save(model);

        public void AddOrUpdate<T>(T model)

            => session.SaveOrUpdate(model);

        public void Remove<T>(T model)

            => session.Delete(model);

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> w = null)

            => w == null ? session.Query<T>() : session.Query<T>().Where(w);


        public async Task<IQueryable<T>> QueryAsync<T>(Expression<Func<T, bool>> w = null)

            => await Task.Run(() => w == null ? session.Query<T>() : session.Query<T>().Where(w));


    }

}
