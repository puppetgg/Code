using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MSWord = Microsoft.Office.Interop.Word;

public class DalCenter
{
    static Queue<string> queueDoc = new Queue<string>();

    public static void Start(string path)
    {
        Task.Factory.StartNew(DalConvertHandle);
        Director(path);
    }
    static int count = 0, success = 0;
    private static void Director(string dir)
    {
        try
        {

            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)
                {
                    Director(fsinfo.FullName);
                }
                else
                {
                    count++;
                    if (fsinfo.FullName.Contains("~$"))
                    {
                        continue;
                    }
                    if (fsinfo.FullName.Contains("$"))
                    {
                        continue;
                    }
                    if (fsinfo.Extension.ToUpper() == ".DOC")
                    {
                        success++;
                        AddFilePath(fsinfo.FullName);
                    }
                    Console.WriteLine("共有" + count + "个文件，成功加载" + success + "文件");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("=====扫描文件====" + e.Message);
        }

    }


    static void DalConvertHandle()
    {
        NewMethod();

        Thread.CurrentThread.IsBackground = true;
        while (true)
        {
            if (queueDoc.Count > 0)
            {
                lock (queueDoc)
                {
                    var doc = queueDoc.Dequeue();
                    string suName = SaveDocx(doc);
                    Console.WriteLine("------处理完成----" + suName);
                }
            }
            Thread.Sleep(50);
        }

    }


    private static void NewMethod()
    {
        string str = "taskkill /im winword.exe /f";

        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
        p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
        p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
        p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
        p.StartInfo.CreateNoWindow = true;//不显示程序窗口
        p.Start();//启动程序

        //向cmd窗口发送输入信息
        p.StandardInput.WriteLine(str + "&exit");

        p.StandardInput.AutoFlush = true;



        //获取cmd窗口的输出信息
        string output = p.StandardOutput.ReadToEnd();


        p.WaitForExit();//等待程序执行完退出进程
        p.Close();
    }

    private static void AddFilePath(string path)
    {
        lock (queueDoc)
            queueDoc.Enqueue(path);
    }
    //static MSWord.Application wordApp = new MSWord.Application();

    private static string SaveDocx(object sourceFileName, bool isDelContext = false)
    {
        MSWord.Application wordApp = new MSWord.Application();
        wordApp.Visible = false;
        object targetFileName = Path.ChangeExtension((string)sourceFileName, "docx");
        object missingValue = System.Reflection.Missing.Value;

        try
        {
            MSWord.Document doc = wordApp.Documents.Open(
                ref sourceFileName,
                ref missingValue, ref missingValue, ref missingValue, ref missingValue,
                ref missingValue, ref missingValue, ref missingValue, ref missingValue,
                ref missingValue, ref missingValue, ref missingValue, ref missingValue,
                ref missingValue, ref missingValue, ref missingValue);

            if (isDelContext)
            {
                doc.Tables[1].Range.Delete(missingValue, missingValue);
                doc.Tables[1].Delete();//.Range.Delete(missingValue, missingValue);
                var sectionCount = wordApp.ActiveDocument.Sections.Count;
                for (int i = 1; i <= sectionCount; i++)
                {
                    wordApp.ActiveDocument.Sections[i].Headers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();
                    wordApp.ActiveDocument.Sections[i].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();

                }

                //---------------------------------------------

                object Unit1 = (int)MSWord.WdUnits.wdCharacter;
                object Count1 = 1;
                var firstLine = doc.Paragraphs.First.Range;
                var content = firstLine.Text.Trim();
                while (string.IsNullOrEmpty(content))
                {
                    firstLine.Delete(ref Unit1, ref Count1);
                    firstLine = doc.Paragraphs.First.Range;
                    content = firstLine.Text.Trim();
                }
                //------------------------删除空白页-------------------
                int pages = doc.ComputeStatistics(MSWord.WdStatistic.wdStatisticPages, ref missingValue);
                object objWhat = MSWord.WdGoToItem.wdGoToPage;
                object objWhich = MSWord.WdGoToDirection.wdGoToAbsolute;
                object objPage = 1;//指定页  

                MSWord.Range range1 = doc.GoTo(ref objWhat, ref objWhich, ref objPage, ref missingValue);

                MSWord.Range range2 = range1.GoToNext(MSWord.WdGoToItem.wdGoToPage);

                object objStart = range1.Start;

                object objEnd = range2.Start;

                if (range1.Start == range2.Start)
                    objEnd = doc.Characters.Count;//最后一页  
                string str = doc.Range(ref objStart, ref objEnd).Text;
                Console.WriteLine(str);

                if (string.IsNullOrEmpty(str.Trim()))
                {

                    object Unit = (int)MSWord.WdUnits.wdCharacter;
                    object Count = 1;
                    doc.Range(ref objStart, ref objEnd).Delete(ref Unit, ref Count);

                }
            }


            object FileFormat = MSWord.WdSaveFormat.wdFormatDocumentDefault;
            object LockComments = false;
            object Password = missingValue;
            object AddToRecentFiles = false;
            object WritePassword = missingValue;
            object ReadOnlyRecommended = false;
            object EmbedTrueTypeFonts = true;
            object SaveNativePictureFormat = missingValue;
            object SaveFormsData = missingValue;
            object SaveAsAOCELetter = missingValue;
            object Encoding = missingValue;
            object InsertLineBreaks = missingValue;
            object AllowSubstitutions = missingValue;
            object LineEnding = missingValue;
            object AddBiDiMarks = missingValue;
            object CompatibilityMode = missingValue;

            doc.SaveAs(ref targetFileName, ref FileFormat,
              ref LockComments, ref Password, ref AddToRecentFiles, ref WritePassword,
              ref ReadOnlyRecommended, ref EmbedTrueTypeFonts, ref SaveNativePictureFormat, ref SaveFormsData,
              ref SaveAsAOCELetter, ref Encoding, ref InsertLineBreaks, ref AllowSubstitutions,
              ref LineEnding, ref AddBiDiMarks);

            wordApp.Documents.Close(ref missingValue, ref missingValue, ref missingValue);

            //关闭进程
            object saveOption = MSWord.WdSaveOptions.wdDoNotSaveChanges;
            wordApp.Application.Quit(ref saveOption, ref missingValue, ref missingValue);

        }
        catch (Exception ex)
        {
            Console.WriteLine("转换错误=====" + ex.Message);
            object saveOption = MSWord.WdSaveOptions.wdDoNotSaveChanges;

            wordApp.Application.Quit(ref saveOption, ref missingValue, ref missingValue);
        }
        return targetFileName as string;
    }


}




class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("输入目录。。。");
        string path = Console.ReadLine();

        path = string.IsNullOrEmpty(path) ? "c:\\3" : path;
        DalCenter.Start(path);
        Console.Read();

    }
}


