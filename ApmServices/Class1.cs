using Abp;
using Abp.Dependency;
using Abp.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmServices
{
    public class Class1
    {

        public bool Test()
        {

            /// 启动abp并初始化
            var startup = AbpBootstrapper.Create<SendMailModule>();
            startup.Initialize();


            // 测试是否可以正常发送
            var emailSender = IocManager.Instance.Resolve<IEmailSender>();
            emailSender.Send("接收地址", "主题", "内容");
            return true;
        }


    }
}
