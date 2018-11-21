using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5Redis消息队列.code
{
    [Serializable]
    public class ChatModels
    {

        public string userId { get; set; }
        public string chat { get; set; }
    }
}