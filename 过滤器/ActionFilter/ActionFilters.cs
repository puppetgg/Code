using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace 过滤器.ActionFilter
{
    public class ActionFilters : HandleErrorAttribute
    {


        string logFilePath = HttpContext.Current.Server.MapPath("/App_Data/");
        public override void OnException(ExceptionContext filterContext)
        {
            var a = base.ExceptionType;
            var b = base.IsDefaultAttribute();
            var c = base.Master;
            var d = base.Order;
            var e = base.TypeId;
            var f = JsonConvert.SerializeObject(filterContext.Exception);

            //构建完整的日志文件名
            string logFileName = logFilePath + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            //获得异常堆栈信息
            string exceptionMsg = filterContext.Exception.ToString();
            //将异常信息写入日志文件中
            File.AppendAllText(logFileName, exceptionMsg, Encoding.Default);

            base.OnException(filterContext);
        }


    }
}