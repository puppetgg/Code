using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDal<T> where T : class, new()
    {
        public string Add(T model)
        {


            return "增加了一个实体"+model.GetHashCode();
        }



    }
}
