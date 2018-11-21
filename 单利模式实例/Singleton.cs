using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单利模式实例
{
    class Singleton
    {
        private Singleton()
        {

        }

        static object obj = new object();
        private static Singleton _singleton;
        public static Singleton GetSingleton()
        {
            //这里做的判断只为提高效率
            if (_singleton == null)
            {
                //线程锁是从进入方法内到方法结束
                lock (obj)
                {
                    //真正意义上的判断是否已创建对象
                    if (_singleton == null)
                    {
                        _singleton = new Singleton();

                    }
                }

            }
            return _singleton;
        }

    }
}
