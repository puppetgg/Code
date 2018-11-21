using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace II.多叉树的实现
{
    public class Node
    {
        public int Id { get; set; }
        public int Pid { get; set; }
        public string Name { get; set; }
        public List<Node> ChildrenArr = new List<Node>();
    }


    class Program
    {
        static void Main(string[] args)
        {

            var tree = new List<Node>()
            {
                new Node(){ Id=100,Name="Name"+100,Pid=1},
                new Node(){ Id=101,Name="Name"+101,Pid=100},
                new Node(){ Id=102,Name="Name"+102,Pid=100},
                new Node(){ Id=103,Name="Name"+103,Pid=100},
                new Node(){ Id=104,Name="Name"+104,Pid=100},
                new Node(){ Id=105,Name="Name"+105,Pid=102},
                new Node(){ Id=106,Name="Name"+106,Pid=102},
                new Node(){ Id=107,Name="Name"+107,Pid=102},
                new Node(){ Id=108,Name="Name"+108,Pid=107},
                new Node(){ Id=109,Name="Name"+109,Pid=107},
                new Node(){ Id=110,Name="Name"+110,Pid=106},
                new Node(){ Id=112,Name="Name"+112,Pid=106},
                new Node(){ Id=113,Name="Name"+113,Pid=106},

            };



            BuildData(tree, tree[0]);

            Console.Read();
        }

        private static void BuildData(List<Node> data, Node rootNode)
        {
            try
            {
                var clst = data.FindAll(x => x.Pid == rootNode.Id);
                if (clst.Count > 0)
                {
                    rootNode.ChildrenArr.AddRange(clst);
                    foreach (var item in clst)
                    {
                        BuildData(data, item);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
