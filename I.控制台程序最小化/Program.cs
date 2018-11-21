using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I.控制台程序最小化
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "渭化集团门禁系统FTP自动上传下载程序";//
            //closebtn();
            ConsoleWin32Helper.SetTitle("渭化集团门禁系统FTP自动上传下载程序");
            ConsoleWin32Helper.ShowFlag = true;
            ConsoleWin32Helper.ShowNotifyIcon();
            ConsoleWin32Helper.ShowHideWindow();
            Thread thread = null;

            while (true) //
            {
                Application.DoEvents();//这句话很重要，是双击的的处理事件

                thread = new Thread(new ThreadStart(getTime));

                thread.Start();//线程开始执行
                Thread.Sleep(1000);//休眠状态
                thread.Abort();//线程终止
            }

        }

        static void getTime()

        {

            string dt = System.DateTime.Now.ToLongTimeString();

            Console.Clear();

            Console.WriteLine(dt);


        }
    }
    class ConsoleWin32Helper
    {
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public static bool ShowFlag = true;
        private static string _Title;

        static ConsoleWin32Helper()
        {
            _NotifyIcon.Icon = new Icon(@"C:\work\web.ico");
            _NotifyIcon.Visible = false;
            _NotifyIcon.Text = _Title;

            ContextMenu menu = new ContextMenu();
            _NotifyIcon.ContextMenu = menu;
            _NotifyIcon.MouseDoubleClick += new MouseEventHandler(_NotifyIcon_MouseDoubleClick);
        }
        static void _NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowHideWindow();
        }
        public static void SetTitle(string p_strTitle)
        {
            _Title = p_strTitle;
        }
        public static void ShowHideWindow()
        {
            IntPtr intptr = FindWindow(null, _Title);
            if (intptr != IntPtr.Zero)
            {
                if (ShowFlag)
                {
                    ShowWindow(intptr, 0);//隐藏　0
                }
                else
                {
                    ShowWindow(intptr, 1);//显示　1
                }
            }
            ShowFlag = !ShowFlag;
        }
        #region 托盘图标
        static NotifyIcon _NotifyIcon = new NotifyIcon();
        public static void ShowNotifyIcon()
        {
            _NotifyIcon.Visible = true;
            _NotifyIcon.ShowBalloonTip(10000, "", "渭化集团门禁系统FTP自动上传下载程序", ToolTipIcon.None);
        }
        public static void HideNotifyIcon()
        {
            _NotifyIcon.Visible = false;
        }
        #endregion
    }
}
