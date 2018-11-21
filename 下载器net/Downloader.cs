using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace 下载器net
{

    public class Downloader
    {
        //声明事件
        public event Action<ProgressChangedEventArgs> ProgressChanged;
        public EventHandler DownloadCompleted;

        //声明SendOrPostCallback委托,通过AsyncOperation.post会将这些调用正确地封送到应用程序模型的合适线程或上下文。
        private SendOrPostCallback onProgressChangedDelegate;
        private SendOrPostCallback onDownloadCompletedDelegate;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Downloader()
        {
            onProgressChangedDelegate = onProgressChanged;
            onDownloadCompletedDelegate = onDownloadComplete;
        }


        // 提供给外部调用的同步方法
        public string DownLoad(string url, string name)
        {
            return DownLoad(url, name, null);
        }

        /// <summary>
        /// 通过AsyncOperation调用onProgressChangedDelegate委托关联该函数，保证运行在合适线程
        /// </summary>
        /// <param name="state"></param>
        private void onProgressChanged(object state)
        {
            ProgressChanged?.Invoke((ProgressChangedEventArgs)state);
        }

        private void onDownloadComplete(object state)
        {
            if (DownloadCompleted != null)
            {
                DownloadCompletedEventArgs e = state as DownloadCompletedEventArgs;
                DownloadCompleted(this, e);
            }
        }

        /// <summary>
        /// 异步下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        public void DownloadAsync(string url, string name)
        {

            //url不能为null
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            //userSuppliedState 参数来唯一地标识每个调用，以便区分执行异步操作的过程中所引发的事件。
            //不唯一的任务 ID 可能会导致您的实现无法正确报告进度和其他事件。
            //代码中应检查是否存在不唯一的任务 ID，并且在检测到不唯一的任务 ID 时引发 SystemArgumentException。
            //由于我们不用监控异步操作状态，所以参数设为null
            AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(null);

            //异步委托调用download，如果不想再声明DownLoadHandler委托，用Action或Fun代替也行。
            Func<string, string, AsyncOperation, string> downLoadHandler = DownLoad;
            downLoadHandler.BeginInvoke("http://pan.baidu.com/movie.avi", "乔布斯传", asyncOp, DownloadCallBack, asyncOp);
        }

        private void DownloadCallBack(IAsyncResult iar)
        {
            AsyncResult aresult = (AsyncResult)iar;
            var dh = aresult.AsyncDelegate as Func<string, string, AsyncOperation, string>;
            string r = dh.EndInvoke(iar);
            AsyncOperation ao = iar.AsyncState as AsyncOperation;
            //特定任务调用此方法后，再调用其相应的 AsyncOperation 对象会引发异常。
            ao.PostOperationCompleted(onDownloadCompletedDelegate, new DownloadCompletedEventArgs(r, null, false, null));
        }



        private string DownLoad(string url, string name, AsyncOperation asyncOp)
        {
            //url不能为null
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            for (int i = 0; i < 10; i++)
            {
                int p = i * 10;
                Console.WriteLine("执行线程:" + Thread.CurrentThread.ManagedThreadId + "，传输进度：" + p + "%");
                Thread.Sleep(1000);
                //asyncOp不为空则是异步
                //在适合于应用程序模型的线程或上下文中调用委托。
                asyncOp?.Post(onProgressChangedDelegate, new ProgressChangedEventArgs(p, null));

            }
            //Application
            return name + "文件下载完成！";
        }
    }
    //声明事件参数
    public class DownloadCompletedEventArgs : AsyncCompletedEventArgs
    {
        private string m_result;
        public DownloadCompletedEventArgs(string result, Exception error, bool cancelled, Object userState)
            : base(error, cancelled, userState)
        {
            m_result = result;
        }
        public string Result
        {
            get
            {
                //只读属性在返回属性值之前应调用 RaiseExceptionIfNecessary 方法。 
                //如果组件的异步辅助代码将某一异常指定给 Error 属性或将 Cancelled 属性设置为 true，
                //则该属性将在客户端尝试读取它的值时引发异常。 这会防止客户端因异步操作失败而访问可能无效的属性。
                RaiseExceptionIfNecessary();
                return m_result;
            }
        }

    }
}