using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    public class 控制反转
    {

        public static void CSHS()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IWaterTool, PressWater>();
            IProple people = container.Resolve<VillagePeople>();
            people.DrinkWater();
         


        }

    }


    //人接口
    public interface IProple
    {
        void DrinkWater();
    }

    //取水接口
    public interface IWaterTool
    {
        string ReturnEater();
    }

    //具体取水方式--水井
    public class PressWater : IWaterTool
    {
        public string ReturnEater()
        {
            return "水---地下水";
        }
    }

    //村民
    public class VillagePeople : IProple
    {
        IWaterTool _pw;
        //构造函数传入具体的取水方式
        public VillagePeople(IWaterTool pw)
        {
            _pw = pw;
        }
        public void DrinkWater()
        {
            Console.WriteLine($"村名有{_pw.ReturnEater()}水喝");
        }
    }



}
