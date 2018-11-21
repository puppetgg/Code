using _5Redis消息队列.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5Redis消息队列.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var redisClient = new RedisHelper(2);
            ViewBag.PageInfo = "this page is Home";
            List<ChatModels> isError = null;
            ViewData["pop"] = MessageQueue.CurrentChatModels == null ? "没有记录" : MessageQueue.CurrentChatModels.chat;
            //目前ListRange()方法会出现RedisTimeOutException，并未找到问题根源，但是不影响代码执行。
            ViewData["MSMQ"] = redisClient.ListRange("MessageQuene") == null
                ? isError = new List<ChatModels>()
                : redisClient.ListRange("MessageQuene").Cast<ChatModels>().ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var redisClient = new RedisHelper(2);
            List<ChatModels> isError = null;
            //消息入列
            redisClient.ListRightPush("MessageQuene", new ChatModels { userId = form["userId"], chat = form["chat"] });
            ViewData["MessageQuene"] = redisClient.ListRange("MessageQuene") == null
                ? isError = new List<ChatModels>()
                : redisClient.ListRange("MessageQuene").Cast<ChatModels>().ToList();
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}