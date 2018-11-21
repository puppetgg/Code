using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownLoadFrm
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            string url = "http://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe";
            txbUrl.Text = url;
            this.btnPause.Enabled = false;

            // Get Total Size of the download file
            GetTotalSize();
            downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Path.GetFileName(this.txbUrl.Text.Trim());
            if (File.Exists(downloadPath))
            {
                FileInfo fileInfo = new FileInfo(downloadPath);
                DownloadSize = (int)fileInfo.Length;
                if (DownloadSize == totalSize)
                {
                    string message = "There is already a file with the same name, "
                           + "do you want to delete it? "
                           + "If not, please change the local path. ";
                    var result = MessageBox.Show(
                        message,
                        "File name conflict: " + downloadPath,
                        MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        File.Delete(downloadPath);
                    }
                    else
                    {
                        progressBar1.Value = (int)(DownloadSize / (float)totalSize * 100);
                        this.btnStart.Enabled = false;
                        this.btnPause.Enabled = false;
                    }
                }
            }
        }
        long totalSize = 0;
        private FileStream fileStream;
        int DownloadSize = 0;
        CancellationTokenSource cts = null;
        string downloadPath = null;
        SynchronizationContext sc;
        Task task = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            fileStream = new FileStream(downloadPath, FileMode.OpenOrCreate);
            btnPause.Enabled = true;
            btnStart.Enabled = false;
            fileStream.Seek(DownloadSize, SeekOrigin.Begin);

            // 捕捉调用线程的同步上下文派生对象
            sc = SynchronizationContext.Current;
            cts = new CancellationTokenSource();
            // 使用指定的操作初始化新的 Task。
            task = new Task(() => Actionmethod(cts.Token), cts.Token);

            // 启动 Task，并将它安排到当前的 TaskScheduler 中执行。
            task.Start();
        }

        private void Actionmethod(CancellationToken ct)
        {
            DownLoadFile(txbUrl.Text.Trim(), ct,
                new Progress<int>(p => sc.Post(new SendOrPostCallback((result) => progressBar1.Value = (int)result), p)));
        }
        // Get Total Size of File
        private void GetTotalSize()
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(txbUrl.Text.Trim());
            HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            totalSize = response.ContentLength;
            response.Close();
        }
        //  Download File
        // CancellationToken 参数赋值获得一个取消请求
        // progress参数负责进度报告
        private void DownLoadFile(string url, CancellationToken ct, IProgress<int> progress)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream responseStream = null;
            int bufferSize = 2048;
            byte[] bufferBytes = new byte[bufferSize];
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                if (DownloadSize != 0)
                    request.AddRange(DownloadSize);

                response = request.GetResponse() as HttpWebResponse;
                responseStream = response.GetResponseStream();
                int readSize = 0;
                while (true)
                {
                    if (ct.IsCancellationRequested)
                    {
                        MessageBox.Show($"下载暂停，下载的文件地址为：{downloadPath}\n 已经下载的字节数为: {DownloadSize}字节");
                        response.Close();
                        fileStream.Close();
                        sc.Post(state => { btnStart.Enabled = true; btnPause.Enabled = false; }, null);

                        // 退出异步操作
                        break;
                    }

                    readSize = responseStream.Read(bufferBytes, 0, bufferBytes.Length);
                    if (readSize > 0)
                    {
                        DownloadSize += readSize;
                        int percentComplete = (int)(DownloadSize / (float)totalSize * 100);
                        progress.Report(percentComplete);
                    }
                    else
                    {
                        MessageBox.Show(String.Format("下载已完成，下载的文件地址为：{0}，文件的总字节数为: {1}字节", downloadPath, totalSize));

                        sc.Post((state) =>
                        {
                            btnStart.Enabled = false;
                            btnPause.Enabled = false;
                        }, null);

                        response.Close();
                        fileStream.Close();
                        break;
                    }

                }

            }
            catch (AggregateException ex)
            {
                // 因为调用Cancel方法会抛出OperationCanceledException异常
                // 将任何OperationCanceledException对象都视为以处理
                ex.Handle(e => e is OperationCanceledException);
            }
        }

    }
}
