using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _2将EAP转化为TAP
{
    public class Class1
    {

        public static void Main()
        {

            AMPWay();
            APMSwitchToTAP();

            Console.WriteLine("ko");

            Console.Read();

        }

        private static void APMSwitchToTAP()
        {
            WebRequest request = WebRequest.Create("https://vscode.cdn.azure.cn/stable/d0182c3417d225529c6d5ad24b7572815d0de9ac/VSCodeSetup-x64-1.23.1.exe");
            Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null, TaskCreationOptions.None).ContinueWith(
                t =>
                {
                    WebResponse webResponse = null;
                    try
                    {
                        webResponse = t.Result;
                        Console.WriteLine("请求的内容大小为aaa： " + webResponse.ContentLength);
                    }
                    catch (Exception ex)
                    {
                        if (ex.GetBaseException() is WebException)
                        {
                            Console.WriteLine("异常发生，aaa异常信息为： " + ex.GetBaseException().Message);
                        }
                        else
                        {
                            throw;
                        }
                    }


                });

        }

        private static void AMPWay()
        {
            WebRequest request = WebRequest.Create("https://vscode.cdn.azure.cn/stable/d0182c3417d225529c6d5ad24b7572815d0de9ac/VSCodeSetup-x64-1.23.1.exe");
            request.BeginGetResponse(res =>
            {
                WebResponse webResponse = null;
                try
                {
                    webResponse = request.EndGetResponse(res);
                    Console.WriteLine("请求的内容大小为： " + webResponse.ContentLength);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("异常发生，异常信息为： " + ex.GetBaseException().Message);
                }
                finally
                {
                    if (webResponse != null)
                    {
                        webResponse.Close();
                    }
                }
            }, null);

        }
    }
}
