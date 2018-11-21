using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace I.WebApiDemo.Controllers
{
    public class ccController : ApiController
    {
        [HttpGet]
        public string GGDD()
        {

            return "123564879";
        }

        [HttpGet]
        public string Get() {
            return "ggggggggggggggggggggggggggggggggggggggggget";
        }
    }
}
