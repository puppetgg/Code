using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace word
{
    //using ExcelOffice = NetOffice.Invoker.
    //using OfficeApi = NetOffice.OfficeApi;
    class Program
    {

        static void Main(string[] args)
        {

            //string guid = Request.QueryString["guid"];

            //模板路径
            //string mWordSrc = "";// Request.PhysicalPath.Replace("WordToPDF.aspx", "\\Temp\\" + guid + ".docx");
            //string mPDFSrc = "";// Request.PhysicalPath.Replace("WordToPDF.aspx", "\\Temp\\" + guid + ".pdf");

            //            NetOffice.Tools.TimestampAttribute



            //Word.Application wordApplication = new Word.Application();
            //Word.Document pDoc = wordApplication.Documents.Open(mWordSrc);
            //pDoc.Activate();

            //pDoc.SaveAs(mPDFSrc, WdSaveFormat.wdFormatPDF);
            //wordApplication.Quit();
            //wordApplication.Dispose();

            //if (System.IO.File.Exists(mPDFSrc))
            //{
            //    byte[] tAryByte = System.IO.File.ReadAllBytes(mPDFSrc);
            //    Response.Clear();
            //    Response.AddHeader("Content-Length", tAryByte.Length.ToString());
            //    Response.AppendHeader("Content-Disposition", string.Format("inline;filename=ExportWord2PDF_{0}.docx", DateTime.Now.ToString("yyMMddHHmmss")));
            //    Response.ContentType = "application/pdf";
            //    Response.BinaryWrite(tAryByte);
            //    Response.Flush();
            //    Response.End();

            //}



        }
    }
}
