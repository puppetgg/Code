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

namespace _1DownLoadFrm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            // 捕捉调用线程的同步上下文派生对象
            SynchronizationContext sc = SynchronizationContext.Current;
            cts = new CancellationTokenSource();
            // 使用指定的操作初始化新的 Task。
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            Task task = new Task(() => Actionmethod(cts.Token, sc), cts.Token);

            // 启动 Task，并将它安排到当前的 TaskScheduler 中执行。 
            task.Start();

        }

        private void Actionmethod(CancellationToken token, SynchronizationContext sc)
        {
            string url = txbUrl.Text.Trim();
            DownLoadFile(url, token, new Progress<int>(p => sc.Post(x => progressBar1.Value = p, p)/*此处的线程为下载下载线程*/), sc);
        }

        CancellationTokenSource cts = null;

        long totalSize = 0;
        int downloadSize = 0;


        private void DownLoadFile(string url, CancellationToken ct, IProgress<int> progress, SynchronizationContext sc)
        {
            Uri uri = new Uri(url);
            string fileName = uri.AbsolutePath.Substring(uri.AbsolutePath.LastIndexOf("/") + 1);
            string downloadPath = @"C:\Users\spadmintest\Desktop\Load\" + fileName;

            byte[] byarr = new byte[1024 * 512];
            FileStream filestream = new FileStream(downloadPath, FileMode.Append);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            if (downloadSize != 0)
                request.AddRange(downloadSize);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (totalSize == 0)
                totalSize = response.ContentLength;
            Stream streamResponse = response.GetResponseStream();
            int readSize = 0;

            while (true)
            {
                if (ct.IsCancellationRequested)
                {
                    MessageBox.Show(String.Format("下载暂停，下载的文件地址为：{0}\n 已经下载的字节数为: {1}字节", downloadPath + fileName, downloadSize));

                    response.Close();
                    filestream.Close();
                    sc.Post(state =>
                    {
                        btnStart.Enabled = true;
                        btnPause.Enabled = false;
                    }, null);

                    // 退出异步操作
                    break;
                }
                readSize = streamResponse.Read(byarr, 0, byarr.Length);
                if (readSize > 0)
                {
                    filestream.Write(byarr, 0, readSize);
                    filestream.Flush();
                    downloadSize += readSize;
                    int percentComplete = (int)(downloadSize / (float)totalSize * 100);
                    // 报告进度
                    progress.Report(percentComplete);
                }
                else
                {
                    MessageBox.Show(String.Format("下载已完成，下载的文件地址为：{0}，文件的总字节数为: {1}字节", downloadPath, totalSize));

                    sc.Post(state =>
                    {
                        btnStart.Enabled = false;
                        btnPause.Enabled = false;
                    }, null);

                    response.Close();
                    filestream.Close();
                    break;
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnStart.Enabled != true)
            {
                cts.Cancel();// = false;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            IDataObject iData = Clipboard.GetDataObject();
            //确定数据的格式是否是你想要的
            if (iData.GetDataPresent(DataFormats.Text))
            {
                //如果是，那就把它粘贴到textbox2里
                txbUrl.Text = (string)iData.GetData(DataFormats.Text);
            }

        }
    }
}
