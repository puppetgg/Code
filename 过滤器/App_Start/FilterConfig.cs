using System.Web;
using System.Web.Mvc;
using 过滤器.ActionFilter;

namespace 过滤器
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ActionFilters());
        }
    }
}
