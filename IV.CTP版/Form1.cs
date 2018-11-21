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

namespace IV.CTP版
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            string url = txbUrl.Text.Trim();
            txbUrl.Text = string.IsNullOrEmpty(txbUrl.Text) ? "http://download.microsoft.com/download/7/0/3/703455ee-a747-4cc8-bd3e-98a615c3aedb/dotNetFx35setup.exe" : txbUrl.Text;
            await DownLoadFile(txbUrl.Text.Trim(), cts.Token, p => progressBar1.Value = p);
        }
        CancellationTokenSource cts = null;

        long totalSize = 0;
        int downloadSize = 0;
        private async Task DownLoadFile(string url, CancellationToken ct, Action<int> act)
        {

            var bufferBytes = new byte[1024 * 512];
            string downloadPath = "aa.exe";
            var filestream = new FileStream(downloadPath, FileMode.OpenOrCreate);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            if (downloadSize != 0)
                req.AddRange(downloadSize);

            var rep = await req.GetResponseAsync();
            if (totalSize == 0)
                totalSize = rep.ContentLength;
            var stream = rep.GetResponseStream();
            int readSize = 0;
            while (true)
            {
                if (cts.IsCancellationRequested)
                {
                    MessageBox.Show(String.Format("下载暂停，下载的文件地址为：{0}\n 已经下载的字节数为: {1}字节", downloadPath, downloadSize));
                    rep.Close();
                    filestream.Close();
                    // 退出异步操作
                    break;
                }
                readSize = await stream.ReadAsync(bufferBytes, 0, bufferBytes.Length);
                if (readSize > 0)
                {
                    await filestream.WriteAsync(bufferBytes, 0, readSize);
                    downloadSize += readSize;
                    int percentComplete = (int)((float)downloadSize / totalSize * 100);
                    act?.Invoke(percentComplete);
                }
                else
                {
                    MessageBox.Show(String.Format("下载已完成，下载的文件地址为：{0}，文件的总字节数为: {1}字节", downloadPath, totalSize));
                    stream.Close();
                    rep.Close();
                    filestream.Close();
                    break;
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
