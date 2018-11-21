using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 学生选课系统采用门面模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("外观模式提供了一个统一的接口，用来访问子系统中的一群接口。外观定义了一个高层接口，让子系统更容易使用。使用外观模式时，我们创建了一个统一的类，用来包装子系统中一个或多个复杂的类，客户端可以直接通过外观类来调用内部子系统中方法，从而外观模式让客户和子系统之间避免了紧耦合。");
            Facade facade = new Facade();

            if (facade.RegisterCourse("abc", "zzz"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }

            Console.Read();



        }
    }


    public class Facade
    {
        private RegisterCourse registerCourse;
        private NotifyStudent notifyStudent;
        public Facade()
        {
            registerCourse = new RegisterCourse();
            notifyStudent = new NotifyStudent();
        }


        public bool RegisterCourse(string courseName, string studentName)
        {
            if (registerCourse.CheckAvailable(courseName))
            {
                return false;
            }
            return notifyStudent.Notify(studentName);

        }

    }

    public class RegisterCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0}是否人数已满", courseName);
            return true;
        }
    }

    // 相当于子系统B
    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    }

}
