using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static _3拼接文档.Program.Model;

namespace _3拼接文档
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var res = ReplaceBookMarks("temp.docx", @"C:\3\1.doc", new Model(), AddContent);
            Console.WriteLine(res);
            Console.Read();
        }

        static string ReplaceBookMarks<T>(string path, string contentPath, T model, Action<string, string, BookmarksNavigator> AddContecnt)
        {
            try
            {
                var doc = new Document(path);
                var bks = doc.Bookmarks;
                BookmarksNavigator nav = new BookmarksNavigator(doc);
                var props = typeof(T).GetProperties();

                for (int k = 0; k < bks.Count; k++)
                {
                    var i = bks[k];

                    nav.MoveToBookmark(i.Name);
                    if (i.Name.Equals("Content"))
                    {
                        AddContecnt?.Invoke(contentPath, i.Name, nav);
                        continue;
                    }

                    object value = string.Empty;

                    var prop = props.FirstOrDefault(_ =>
                    ((BkNameAttribute)_.GetCustomAttribute(typeof(BkNameAttribute), false)).DisplayName.Equals(i.Name));
                    value = prop?.GetValue(model);
                    if (value != null)
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






        private static void AddContent(string originFilePath, string markName, BookmarksNavigator nav)
        {
            if (string.IsNullOrEmpty(originFilePath))
                return;
            var doc = new Document();
            doc.LoadFromFileInReadMode(originFilePath, FileFormat.Auto);

            foreach (Section sec in doc.Sections)
            {
                var parahs = sec.Paragraphs;
                if (parahs == null || parahs.Count == 0)
                    continue;
                var section = sec.Clone();
                section.HeadersFooters.LinkToPrevious = true;

                nav.Document.Sections.Add(section);
            }
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
        }
    }
}
