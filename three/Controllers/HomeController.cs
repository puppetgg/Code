using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using three.Models;

namespace three.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            int startId = Thread.CurrentThread.ManagedThreadId;
            ViewData["Message"] = "Your application description page.";
            await Task.Run(() =>
            {
                Thread.Sleep(5000);

                ViewData["Message"] = "方法开始id:" + startId + "---异步id:" + Thread.CurrentThread.ManagedThreadId;

            });
            ViewData["Message"] += "方法结线程：" + Thread.CurrentThread.ManagedThreadId;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
