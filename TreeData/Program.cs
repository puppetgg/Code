using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeData
{
    class Program
    {
        static void Main(string[] args)
        {

            var dal = new DataLogic();
            var datas = dal.GetModels();
            Console.WriteLine(datas.Count() + "=============");
            var ss = datas.First(x => x.Path == "pppp");
            //dal.Add1(new Manage_Type() { Path = "pppp" });
            //datas = dal.GetModels();
            Console.WriteLine(datas.Count() + "---------");
            // RecursionAnalyseExecel();
            Console.Read();
        }



        //解析excel
        public static List<Manage_Type> RecursionAnalyseExecel()
        {
            //1.读取
            FileStream fs = File.OpenRead(@"C:\\work\222.xlsx");
            //1.1获取execel文档
            IWorkbook workBook = new XSSFWorkbook(fs);
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            //实例文档表数量
            var countSheet = workBook.NumberOfSheets;
            var countRow = 0;// sheet.LastRowNum;
            var countCell = 0;// row.LastCellNum;
            var thePointedSheet = 0;

            Manage_Type model = new Manage_Type();
            List<Manage_Type> listModel = new List<Manage_Type>();
            var rootId = "1d9e56bd-3064-4dc8-aeef-5c4479903b05";

            string[] ApproverAccount = { "Corporate Manuals", "Global & Site Specific Procedures",
                "Global & Site Specific Regulations", "Operation Instructions","Technical Specifications","SOP" };

            var arrTemp = new Manage_Type[10];
            arrTemp[0] = new Manage_Type() { Id = rootId, ApproverAccount = ApproverAccount[0] };
            //数据表对象
            sheet = workBook.GetSheetAt(0);


            for (int i = 0; i < countSheet; i++)
            {
                //获取当前sheet
                sheet = workBook.GetSheetAt(i);
                //设置制定页
                if (thePointedSheet != 0)
                {
                    sheet = workBook.GetSheetAt(thePointedSheet);
                    countSheet = 0;
                }
                countRow = sheet.LastRowNum;
                for (int j = 1; j <= countRow; j++)
                {
                    row = sheet.GetRow(j);
                    countCell = row.Cells.Count;

                    bool isNewRow = true;
                    //判断是否为根目录
                    isNewRow = IsRootPath(row);
                    //添加列
                    for (int m = 1; m <= countCell; m++)
                    {
                        cell = row.GetCell(m);
                        if (cell == null || string.IsNullOrEmpty(cell.StringCellValue))
                            continue;
                        model = new Manage_Type
                        {
                            ApproverAccount = ApproverAccount[workBook.GetSheetIndex(sheet)],
                            TypeName = cell.StringCellValue,
                            ParentId = arrTemp[m - 1].Id
                        };

                        if (isNewRow)
                            arrTemp[m] = model;

                        listModel.Add(model);

                    }


                }
            }
            return listModel;
        }



        //判断是否为根目录
        private static bool IsRootPath(IRow row)
        {
            bool isNewRow = true;
            var countCell = row.Cells.Count - 2;
            if (row.Cells.Count <= 2 || string.IsNullOrEmpty(row.GetCell(countCell).StringCellValue))
            {
                isNewRow = false;
            }
            return isNewRow;
        }






    }
}
