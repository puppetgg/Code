using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 过滤器.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            int b = 0;
            int a = 9 / b;



            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            Tnt.TTT();
            ViewBag.Message = AppDomain.CurrentDomain.BaseDirectory;

            return View();
        }
    }
}