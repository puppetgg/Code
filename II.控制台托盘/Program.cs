using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

class Program
{
    static FileSystemWatcher watcher = new FileSystemWatcher();
    static bool _IsExit = false;
    static void Main(string[] args)
    {
        Console.Title = "CodeDemo监控";
        ConsoleWin32Helper.ShowNotifyIcon();
        ConsoleWin32Helper.DisableCloseButton(Console.Title);
        //Task.Run(() =>);
  
        //Thread threadMonitorInput = new Thread(new ThreadStart(MonitorInput));
        //threadMonitorInput.Start();
        //while (true)
        //{
        //    Application.DoEvents();
        //    if (_IsExit)
        //    {
        //        break;
        //    }
        //}

        TestFileSystemWatcher();
        Console.Read();
    }

    static void TestFileSystemWatcher()
    {

        try
        {
            watcher.Path = @"Z:\CodeDemo";
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        //设置监视文件的哪些修改行为
        watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.LastAccess | NotifyFilters.LastWrite
            | NotifyFilters.FileName | NotifyFilters.DirectoryName;


        watcher.Filter = "*";

        watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.Created += new FileSystemEventHandler(OnChanged);
        watcher.Deleted += new FileSystemEventHandler(OnChanged);
        watcher.Renamed += new RenamedEventHandler(OnRenamed);

        watcher.EnableRaisingEvents = true;
        while (Console.ReadLine() != "q") ;

    }
    static void OnChanged(object source, FileSystemEventArgs e)
    {
        string msg = string.Format("File：{0} {1}！", e.FullPath, e.ChangeType);
        // redis.ListRightPush("popmsg", msg);
        Console.WriteLine(msg);
    }

    static void OnRenamed(object source, RenamedEventArgs e)
    {
        string msg = string.Format("File：{0} renamed to\n{1}", e.OldFullPath, e.FullPath);
        //redis.ListRightPush("popmsg", msg);
        Console.WriteLine(msg);
    }


    static void MonitorInput()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "exit")
            {
                _IsExit = true;
                Thread.CurrentThread.Abort();
            }
        }

    }
    class ConsoleWin32Helper
    {
        static ConsoleWin32Helper()
        {
            _NotifyIcon.Icon = new Icon(@"C:\work\web.ico");
            _NotifyIcon.Visible = false;
            _NotifyIcon.Text = "tray";
            ContextMenu menu = new ContextMenu();
            MenuItem item = new MenuItem();
            item.Text = "右键菜单，还没有添加事件";
            item.Index = 0;
            menu.MenuItems.Add(item);
            _NotifyIcon.ContextMenu = menu;
            _NotifyIcon.MouseDoubleClick += new MouseEventHandler(_NotifyIcon_MouseDoubleClick);
        }
        static bool isClose = false;
        static void _NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (isClose)
            {
                isClose = false;
                Hidden();
            }
            else
            {
                Show();
                isClose = true;
            }
        }
        #region 禁用关闭按钮
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);
        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        static extern IntPtr RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        [DllImport("User32.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(IntPtr hwind, int cmdShow);
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hwind);

        ///<summary>
        /// 禁用关闭按钮
        ///</summary>
        ///<param name="consoleName">控制台名字</param>
        public static void DisableCloseButton(string title)//线程睡眠，确保closebtn中能够正常FindWindow，否则有时会Find失败。。 
        {
            Thread.Sleep(100);
            IntPtr windowHandle = FindWindow(null, title);
            IntPtr closeMenu = GetSystemMenu(windowHandle, IntPtr.Zero);
            uint SC_CLOSE = 0xF060;
            RemoveMenu(closeMenu, SC_CLOSE, 0x0);
        }
        public static bool IsExistsConsole(string title)
        {
            IntPtr windowHandle = FindWindow(null, title);
            if (windowHandle.Equals(IntPtr.Zero))
            {
                return false;
            }
            return true;
        }

        public static void Hidden()
        {
            IntPtr ParenthWnd = new IntPtr(0);
            IntPtr et = new IntPtr(0);
            ParenthWnd = FindWindow(null, "Test2");
            int normalState = 0;//窗口状态(隐藏)
            ShowWindow(ParenthWnd, normalState);
        }

        public static void Show()
        {
            IntPtr ParenthWnd = new IntPtr(0);
            IntPtr et = new IntPtr(0);
            ParenthWnd = FindWindow(null, "Test2");
            int normalState = 9;//窗口状态(隐藏)
            ShowWindow(ParenthWnd, normalState);
        }

        #endregion
        #region 托盘图标
        static NotifyIcon _NotifyIcon = new NotifyIcon();
        public static void ShowNotifyIcon()
        {
            _NotifyIcon.Visible = true;
            _NotifyIcon.ShowBalloonTip(3000, "", "我是托盘图标，用右键点击我试试，还可以双击看看。", ToolTipIcon.None);
        }
        public static void HideNotifyIcon()
        {
            _NotifyIcon.Visible = false;
        }
        #endregion
    }
}