using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DalCenter.Model;
using MSWord = Microsoft.Office.Interop.Word;

public class DalCenter
{



    private static void KILLWord()
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

    public static string SaveDocx(object sourceFileName, bool isDelContext = false)
    {
        KILLWord();
        MSWord.Application wordApp = new MSWord.Application();
        wordApp.Visible = false;
        sourceFileName = @"Z:\CodeDemo\书签替换\bin\Debug\temp.docx";
        object targetFileName = @"Z:\CodeDemo\书签替换\bin\Debug\" + DateTime.Now.ToString("yyyyMMddHHMMSS") + ".pdf";
        object missingValue = Missing.Value;

        try
        {
            MSWord.Document doc = wordApp.Documents.Open(
                ref sourceFileName,
                ref missingValue, ref missingValue, ref missingValue, ref missingValue,
                ref missingValue, ref missingValue, ref missingValue, ref missingValue,
                ref missingValue, ref missingValue, ref missingValue, ref missingValue,
                ref missingValue, ref missingValue, ref missingValue);


            ReplaceBookMarks(doc, new Model());


            object FileFormat = MSWord.WdSaveFormat.wdFormatPDF;
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


    static string ReplaceBookMarks<T>(MSWord.Document doc, T model)
    {
        try
        {
            var props = typeof(T).GetProperties().Where(x => x.CustomAttributes.Count() != 0).ToList();
            foreach (var prop in props)
            {
                var propAttr = prop.GetCustomAttribute(typeof(BkNameAttribute), false);
                if (propAttr == null) continue;
                var propVal = prop.GetValue(model);
                var propAttrVal = (propAttr as BkNameAttribute).DisplayName;
                object bkName = propAttrVal;
                MSWord.Range range = null;
                if (propAttrVal.Contains("_"))//带选型的标签
                {
                    bkName = propAttrVal + propVal;
                    range = doc.Bookmarks.get_Item(ref bkName).Range;//表格插入位置   
                    range.Text = "";
                    continue;
                }
                range = doc.Bookmarks.get_Item(ref bkName).Range;
                range.Text = propVal.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return "ok";
    }
    public class Model
    {
        public class BkNameAttribute : DisplayNameAttribute { public BkNameAttribute(string name) : base(name) { } }
        [BkName("DocTitle")]
        public string DocumentTitle { get; set; } = "The voice of China";
        [BkName("DocNo")]
        public string DocNo { get; set; } = "oppo  meizu 10";
        [BkName("SupplyChainPlatform")]
        public string SupplyChainPlatform { get; set; } = "Windows for All";
        [BkName("Version")]
        public string Version { get; set; } = "GB2312";
        [BkName("Content")]
        public string Content { get; set; } = "MicroSoft Visual Studio";
        [BkName("UpdataDate")]
        public string UpdataDate { get; set; } = DateTime.Now.ToString("yyyy.MM.dd");
        [BkName("InureDate")]
        public string InureDate { get; set; } = DateTime.Now.ToString("yyyy.MM.dd");
        [BkName("AppliedTo_")]
        public string AppliedTo { get; set; } = "C";
    }

}


class Program
{
    static void Main(string[] args)
    {
        DalCenter.SaveDocx("d");
        Console.Read();
    }
}

