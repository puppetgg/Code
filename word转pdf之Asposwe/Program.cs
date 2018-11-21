using Aspose.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace word转pdf之Asposwe
{
    class Program
    {
        static void Main(string[] args)
        {

            //读取doc文档
            Document doc = new Document(@"C:\work\测试论证\Task编程\sorce\222.doc");
            //保存为PDF文件，此处的SaveFormat支持很多种格式，如图片，epub,rtf 等等
            doc.Save("temp.pdf", SaveFormat.Pdf);
        }
    }
}
