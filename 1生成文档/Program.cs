using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1生成文档
{
    class Program
    {
        static void Main(string[] args)
        {  //Create word document  
            Document document = new Document();
            //Get a section  
            Section section = document.AddSection();
            //Get a paragraph  
            Paragraph para = section.AddParagraph();

            document.SaveToFile("Sample.docx", FileFormat.Docx);
            //WordDocView("Sample.docx");


            document.LoadFromFile(@"Sample.docx");
            Paragraph para1 = document.Sections[0].Paragraphs[0];
            para1.AppendText("i am a test!");
            document.SaveToFile("Sample.docx", FileFormat.Docx);
            WordDocView("Sample.docx");

        }

        private static void WordDocView(string fileName)
        {
            try
            {
                Process.Start(fileName);
            }
            catch { }
        }
    }
}
