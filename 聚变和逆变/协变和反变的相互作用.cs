using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 聚变和逆变
{



    internal interface IFoo<in T>
    {


    }

    internal interface IBar<out T>
    {
        void TT(IFoo<T> foo);
    }

    public class 协变和反变的相互作用
    {
        public void yy()
        {
            IBar<string> strBar = null;

            IBar<object> objBar = null;

            objBar = strBar;

            
            //objBar.
        }
    }
}
