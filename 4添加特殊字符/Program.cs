using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static _4添加特殊字符.Program.Model;

namespace _4添加特殊字符
{
    class Program
    {
        static void Main()
        {
            var res = ReplaceBookMarks("temp.docx", @"C:\3\1.doc", new Model());
            Console.WriteLine(res);
            Console.Read();
        }

        static string ReplaceBookMarks<T>(string path, string contentPath, T model)
        {
            try
            {
                var doc = new Document(path);
                var bks = doc.Bookmarks;
                BookmarksNavigator nav = new BookmarksNavigator(doc);
                var props = typeof(T).GetProperties().Where(x => x.CustomAttributes.Count() != 0).ToList();
                Bookmark bk = null;
                //遍历属性
                foreach (var prop in props)
                {
                    var propAttr = prop.GetCustomAttribute(typeof(BkNameAttribute), false);
                    if (propAttr == null)
                        continue;
                    var propAttrVal = (propAttr as BkNameAttribute).DisplayName;

                    if (propAttrVal.Contains("_"))//带选型的标签
                    {
                        var propVal = prop.GetValue(model);
                        bk = bks.FindByName(propAttrVal + propVal);
                        if (bk == null)
                            continue;
                        nav.MoveToBookmark(propAttrVal + propVal);
                        nav.ReplaceBookmarkContent("", true);
                        continue;
                    }
                    bk = bks.FindByName(propAttrVal);
                    if (bk == null)
                        continue;
                    nav.MoveToBookmark(bk.Name);
                    var value = prop.GetValue(model);
                    if (string.IsNullOrEmpty(value.ToString()))
                        continue;
                    nav.ReplaceBookmarkContent(value.ToString(), true);

                }

                doc.SaveToFile("doc.docx", FileFormat.Docx);
                doc.Clone().Dispose();
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
}
