using Abp.Configuration;
using Abp.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmServices
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
                         {
                           new SettingDefinition(EmailSettingNames.Smtp.EnableSsl, "true"),
                           new SettingDefinition(EmailSettingNames.Smtp.UseDefaultCredentials, "false"),
                           new SettingDefinition(EmailSettingNames.Smtp.UserName, "自定义账号"),
                           new SettingDefinition(EmailSettingNames.Smtp.Password, "自定义密码"),
                           new SettingDefinition(EmailSettingNames.Smtp.Host, "smtp.qq.com（smtp服务器）"),
                           new SettingDefinition(EmailSettingNames.Smtp.Port, "25(smtp端口)"),
                           new SettingDefinition(EmailSettingNames.DefaultFromAddress, "自定义邮箱，一定要有这个"),
                           new SettingDefinition(EmailSettingNames.DefaultFromDisplayName, "自定义显示名称")
                       };


        }
    }
}
