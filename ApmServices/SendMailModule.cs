using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmServices
{
    public class SendMailModule : AbpModule
    {


        public override void PreInitialize()
        {
            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
        }

        public override void PostInitialize()
        {
        }
        
    }
}
