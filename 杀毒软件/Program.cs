using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 杀毒软件
{
    class Program
    {
        static void Main(string[] args)
        {
            Director d1 = new Director("sunny的资料");
            Director d2 = new Director("图像文件");
            Director d3 = new Director("文本文件");

            d1.picLst.Add(new Picture() { Name = "图片1" });
            d1.picLst.Add(new Picture() { Name = "图片2" });

            d2.txtLst.Add(new Text() { Name = "文本1" });
            d2.txtLst.Add(new Text() { Name = "文本2" });

            d3.dirLst.AddRange(new Director[] { d1, d2 });

            d3.killVirus();



            Console.Read();
        }
    }

    public class Picture
    {
        public string Name { get; set; }
        public void killVirus()
        {
            Console.WriteLine($"对{Name}图片文件进行查杀");
        }

    }
    public class Text
    {
        public string Name { get; set; }
        public void killVirus()
        {
            Console.WriteLine($"对{Name}文本文件进行查杀");
        }

    }

    public class Director
    {
        public Director(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public List<Text> txtLst = new List<Text>();
        public List<Picture> picLst = new List<Picture>();
        public List<Director> dirLst = new List<Director>();
        public void killVirus()
        {
            Console.WriteLine($"对{Name}文件夹进行查杀");
            foreach (var item in dirLst)
            {
                item.killVirus();
            }
            foreach (var item in picLst)
            {
                item.killVirus();
            }
            foreach (var item in txtLst)
            {
                item.killVirus();
            }
        }


    }


}
