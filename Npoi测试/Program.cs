using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Npoi测试
{
    class Program
    {
        static void Main(string[] args)
        {

            MyClass.CreateExcel();
            
        }
    }

    public class MyClass
    {
        public static void CreateExcel()
        {

            FileStream fs = File.Create("zhxl.xls");
            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet = workbook.CreateSheet();

            for (int i = 0; i < 100; i++)
            {
                IRow row = sheet.CreateRow(i);
                for (int j = 0; j < 120; j++)
                {
                    row.CreateCell(j, CellType.String).SetCellValue(j + "ddd"+ "Main file: 1.For corporate restructuring, update document format and logo.Add scope for “All”. 2.Update document template: move the old revision to the end of the document and just put the latest change description in page1 3.Update title from “XMC QSM Engineer Training O.I.” to “QSM Engineer Training O.I.” 4.Add training item: ESH Manual Introduction in item 7.1.4. 5.Update all “paper exam” to “Quiz” in item7.1.4. 6.Add “e - certification system” in item7.6.1.Attachments: 1.Update attachments logo. 2.Delete “XMC” wording in all attachments’ title because this document is not only for XMC. 3.Update “paper exam” to “Quiz” in all attachments. 4.Add training item: ESH Manual Introduction in attachment003."
)
                            ;
                    Console.WriteLine("ss" + i + "   " + j);
                }
            }

            workbook.Write(fs);

        }
    }

}
