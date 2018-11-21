using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 采用组合模式的杀毒软件
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"  
                    组合模式的关键是定义了一个抽象构件类，它既可以代表叶子，
                    又可以代表容器，而客户端针对该抽象构件类进行编程，无须知道它到底表示的是叶子还是容器，可以对其进行统一处理。
                    同时容器对象与抽象构件类之间还建立一个聚合关联关系，在容器对象中既可以包含叶子，也可以包含容器，
                    以此实现递归组合，形成一个树形结构。");
            //针对抽象构件编程  
            AbstractFile file1, file2, file3, file4, file5, folder1, folder2, folder3, folder4;

            folder1 = new Folder("Sunny的资料");
            folder2 = new Folder("图像文件");
            folder3 = new Folder("文本文件");
            folder4 = new Folder("视频文件");

            file1 = new ImageFile("小龙女.jpg");
            file2 = new ImageFile("张无忌.gif");
            file3 = new TextFile("九阴真经.txt");
            file4 = new TextFile("葵花宝典.doc");
            //file5 = new VideoFile("笑傲江湖.rmvb");

            folder2.Add(file1);
            folder2.Add(file2);
            folder3.Add(file3);
            folder3.Add(file4);
            //folder4.Add(file5);
            folder1.Add(folder2);
            folder1.Add(folder3);
            folder1.Add(folder4);

            //从“Sunny的资料”节点开始进行杀毒操作  
            folder1.KillVirus();

            Console.Read();
        }
    }

    public abstract class AbstractFile
    {
        public abstract void Add(AbstractFile c);
        public abstract void Remove(AbstractFile c);
        public abstract AbstractFile GetChild(int i);
        public abstract void KillVirus();

    }

    public class Folder : AbstractFile
    {
        private List<AbstractFile> list = new List<AbstractFile>();
        public override void Add(AbstractFile c)
        {
            list.Add(c);
        }

        public override AbstractFile GetChild(int i)
        {
            return list[i];
        }

        private string name;

        public Folder(string name)
        {
            this.name = name;
        }
        public override void KillVirus()
        {
            Console.WriteLine("****对文件夹'" + name + "'进行杀毒");

            foreach (var item in list)
            {
                item.KillVirus();
            }
        }

        public override void Remove(AbstractFile c)
        {
            list.Remove(c);
        }
    }

    public class ImageFile : AbstractFile
    {
        private string name;
        public ImageFile(string name)
        {
            this.name = name;
        }
        public override void Add(AbstractFile c)
        {
            Console.WriteLine("错误");
        }

        public override AbstractFile GetChild(int i)
        {
            Console.WriteLine("错误");
            return null;
        }
        public override void KillVirus()
        {
            //模拟杀毒  
            Console.WriteLine("----对图像文件'" + name + "'进行杀毒");
        }

        public override void Remove(AbstractFile c)
        {
            Console.WriteLine("错误");

        }
    }

    public class TextFile : AbstractFile
    {
        private string name;
        public TextFile(string name)
        {
            this.name = name;
        }
        public override void Add(AbstractFile c)
        {
            Console.WriteLine("错误");
        }

        public override AbstractFile GetChild(int i)
        {
            Console.WriteLine("错误");
            return null;
        }
        public override void KillVirus()
        {
            //模拟杀毒  
            Console.WriteLine("----对文本文件'" + name + "'进行杀毒");
        }

        public override void Remove(AbstractFile c)
        {
            Console.WriteLine("错误");

        }
    }
}
