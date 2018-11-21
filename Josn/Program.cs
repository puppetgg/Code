using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josn
{
    class Program
    {
        static void Main(string[] args)

        {
            //newtonsoftJosn.DoJsonTest();
            LinqToJsonTT.LinqToJS();


            string jsonText = "[{'a':'aaa','b':'bbb','c':'ccc'},{'a':'aa','b':'bb','c':'cc'}]";

            JArray mJObj = JArray.Parse(jsonText);

            //需求，删除列表里的a节点的值为'aa'的项

            IList<JToken> delList = new List<JToken>(); //存储需要删除的项

            foreach (var ss in mJObj)  //查找某个字段与值
            {
                if (((JObject)ss)["a"].ToString() == "aa")

                    delList.Add(ss);
            }

            foreach (var item in delList)  //移除mJObj  在delList 里的项
            {

                mJObj.Remove(item);
            }


            //---------------------------------------------------------------
            string json = "{\"offlineLock\":{\"id\":\"4028d808581dab0f01581db51405001e\",\"mac\":\"D4:3D:7E:5F:B7:44\",\"sdsl\":5,\"sdrq\":1477967156304,\"shlb\":\"0\"},\"flag\":\"success\",\"status\":\"1400\",\"resultList\":[{\"id\":\"4028d808581dab0f01581db5145c001f\",\"zwjyzsbh\":\"1000001600000052\",\"sfyfz\":\"0\"},{\"id\":\"4028d808581dab0f01581db514780020\",\"zwjyzsbh\":\"1000001600000054\",\"sfyfz\":\"0\"},{\"id\":\"4028d808581dab0f01581db514950021\",\"zwjyzsbh\":\"1000001600000056\",\"sfyfz\":\"0\"},{\"id\":\"4028d808581dab0f01581db514b20022\",\"zwjyzsbh\":\"1000001600000058\",\"sfyfz\":\"0\"},{\"id\":\"4028d808581dab0f01581db514cc0023\",\"zwjyzsbh\":\"1000001600000060\",\"sfyfz\":\"0\"}]}";

            JObject jo = (JObject)JsonConvert.DeserializeObject(json);
            string id = jo["offlineLock"]["id"].ToString();
            Console.WriteLine(id);

            Console.ReadLine();
            //----------------------------------------------------


            //2.2 非数组用JObject加载 （这里主要以这个为例子）

            string jsonText1 = "{'a':'aaa','b':'bbb','c':'ccc'}";

            JObject mJObj1 = JObject.Parse(jsonText1);

            mJObj.Add("v"); //新增，没试过

            //var v1 = mJObj[a].ToString()  //得到'aaa'的值
        }
    }
}
