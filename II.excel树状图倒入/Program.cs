using NHCURT;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II.excel树状图倒入
{
    class Program
    {
        private static object JsonConvert;

        //解析excel
        public static List<Manage_Type> RecursionAnalyseExecel(string path, string rootId, int pointSheet = -1)
        {
            //1.读取
            FileStream fs = File.OpenRead(path);
            //1.1获取execel文档
            IWorkbook workBook = new XSSFWorkbook(fs);
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            //实例文档表数量
            var countSheet = workBook.NumberOfSheets;
            var countRow = 0;// sheet.LastRowNum;
            var countCell = 0;// row.LastCellNum;
            var thePointedSheet = pointSheet;

            Manage_Type model = new Manage_Type();
            List<Manage_Type> listModel = new List<Manage_Type>();

            var arrTemp = new Manage_Type[10];
            arrTemp[0] = new Manage_Type() { Id = rootId };
            //数据表对象
            sheet = workBook.GetSheetAt(0);

            for (int i = 0; i < countSheet; i++)
            {
                //获取当前sheet
                sheet = workBook.GetSheetAt(i);
                //设置指定页
                if (thePointedSheet > -1)
                {
                    sheet = workBook.GetSheetAt(thePointedSheet);
                    countSheet = 0;
                }
                countRow = sheet.LastRowNum;
                for (int j = 1; j <= countRow; j++)
                {
                    row = sheet.GetRow(j);
                    var isnullrow = row.ToString();
                    if (string.IsNullOrEmpty(isnullrow))
                        continue;

                    bool isNewRow = true;
                    //判断是否为根目录
                    isNewRow = !string.IsNullOrEmpty(row.GetCell(0).StringCellValue);
                    //添加列
                    for (int m = 0; m < 2; m++)
                    {
                        cell = row.GetCell(m);
                        if (cell == null || string.IsNullOrEmpty(cell.StringCellValue))
                            continue;

                        model = new Manage_Type
                        {
                            TypeName = cell.StringCellValue,
                            ParentId = arrTemp[m].Id
                        };
                        if (m == 1 && row.Cells.Count == 3)
                            model.AdminName = row.GetCell(2)?.StringCellValue;
                        if (isNewRow && m == 0)
                            arrTemp[m + 1] = model;
                        listModel.Add(model);
                    }
                }
            }
            return listModel;
        }



        static void Main(string[] args)
        {
            //var model1 = new Manage_Type() { TypeName = "CorporateManuals", ParentId = "1" };
            //var list = RecursionAnalyseExecel("1.xlsx", model1.Id, 0);
            //list.Add(model1);

            //var model2 = new Manage_Type() { TypeName = "ProcessAbbreviation", ParentId = "1" };
            //var list2 = RecursionAnalyseExecel("2.xlsx", "1d9e56bd-3064-4dc8-aeef-5c4479903b05");
            // list2.Add(model2);

            //var model3 = new Manage_Type() { TypeName = "Document Category", ParentId = "1" };
            //var list3 = RecursionAnalyseExecel("1.xlsx", "c649b8f3-8675-4e2d-8333-545a19010b47",2);
            //  list3.Add(model3);

            DataLogic dal = new DataLogic();

            var bb = dal.Query<Manage_Type>();
            var cc = bb.Select(x => x.AdminName);

            var ss = cc.First();
            Console.WriteLine("-----------------------");
            Console.WriteLine(ss);
            //Console.WriteLine();
            //list.AddRange(list2);
            //list.AddRange(list3);


            //list3.ForEach(x => dal.Add(x));
            //var res = dal.SaveChange();
            // Console.WriteLine(res.Key + res.Value);
            Console.Read();

        }
    }
}
