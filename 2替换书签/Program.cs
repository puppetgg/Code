using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static _2替换书签.Model;

namespace _2替换书签
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = ReplaceBookMarks("temp.docx", new Model());


            Console.WriteLine(arr);

            Console.Read();
        }



        static string ReplaceBookMarks<T>(string path, T model)
        {
            var doc = new Document(path);
            var bks = doc.Bookmarks;
            BookmarksNavigator nav = new BookmarksNavigator(doc);
            var props = typeof(T).GetProperties();

            for (int k = 0; k < bks.Count; k++)
            {
                var i = bks[k];

                nav.MoveToBookmark(i.Name);
                object value = string.Empty;

                var prop = props.FirstOrDefault(_ =>
                ((BkNameAttribute)_.GetCustomAttribute(typeof(BkNameAttribute), false)).DisplayName.Equals(i.Name));
                value = prop?.GetValue(model);
                if (value != null)
                    nav.ReplaceBookmarkContent(value.ToString(), true);
            }

            doc.SaveToFile("doc.docx", FileFormat.Docx);
            return "ok";
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
