using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bing壁纸设置
{
    public class BingPngDownLaod
    {

        public static void DownLoadPngFromUrl()
        {


            //1.下载链接
            WebClient webCli = new WebClient();
            webCli.Credentials = CredentialCache.DefaultCredentials;
            byte[] pageData = webCli.DownloadData("https://cn.bing.com/HPImageArchive.aspx?idx=0&n=1"); //从指定网站下载数据
            string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句  

            Console.WriteLine(pageHtml);

            Regex regex = new Regex("<Url>(?<MyUrl>.*?)</Url>", RegexOptions.IgnoreCase);


            Console.ReadKey();
            //MatchCollection collection = regex.Matches(xmlDoc);
            // 取得匹配项列表
            //string ImageUrl = "http://www.bing.com" + collection[0].Groups["MyUrl"].Value;
            //if (true)
            //{
            //    ImageUrl = ImageUrl.Replace("1366x768", "1920x1080");
            //}






        }



    }
}
