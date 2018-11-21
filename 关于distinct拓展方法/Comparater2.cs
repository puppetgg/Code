using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 关于distinct拓展方法
{
    class Comparater2 : IComparable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }




    class MyClass2 : IComparer
    {
        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }



    class MyClass3 : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
