using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace 自定义异步事件
{
    public class DoenLaodHandle
    {
        public EventHandler downLoadEventHandler;

        private SendOrPostCallback onProgressChangedDelegate;
        public SendOrPostCallback onDownloadCompletedDelegate;

        AsyncOperation asyncOpe = AsyncOperationManager.CreateOperation(null);
        public void DownloadAsync(string url, string name)
        {

            Func<string, string, AsyncOperation, string> downLoadHandler = MainDownLoad;
            downLoadHandler.BeginInvoke("www.w.w", "ddd", asyncOpe, DownLoadCallBack, downLoadHandler);
        }

        private void DownLoadCallBack(IAsyncResult ar)
        {
            var del = ar.AsyncState as Func<string, string, AsyncOperation, string>;
            var res = del.EndInvoke(ar);
            asyncOpe.PostOperationCompleted(onDownloadCompletedDelegate, new AsyncCompletedEventArgs(null, false, res));
        }

        private string MainDownLoad(string url, string name, AsyncOperation asyncOp)
        {

            for (int i = 0; i < 10; i++)
            {
                int p = i * 10;
                Console.WriteLine("执行线程:" + Thread.CurrentThread.ManagedThreadId + "，传输进度：" + p + "%");
                Thread.Sleep(1000);
                asyncOp?.Post(onProgressChangedDelegate, new ProgressChangedEventArgs(p, null));
            }
            return name + "DownLaoded!";
        }


    }


}