using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Josn
{
    public class LinqToJsonTT
    {
        public static void LinqToJS()
        {
            Action<string> con = Console.WriteLine;
            //1.创建jsobject
            con("-----------------------1.创建jsobject---------------");
            var jObj = new JObject();
            jObj.Add(new JProperty("Name", "Nancy"));
            jObj.Add(new JProperty("Age", 18));
            jObj.Add(new JProperty("Leader", new JObject() { new JProperty("Lucy", "gender"), new JProperty("Age", 22) }));
            Console.WriteLine(jObj.ToString());
            con("-------------------1.事例----------------------------");
            JObject staff = new JObject();
            staff.Add(new JProperty("Name", "Jack"));
            staff.Add(new JProperty("Age", 33));
            staff.Add(new JProperty("Department", "Personnel Department"));
            staff.Add(new JProperty("Leader", new JObject(new JProperty("Name", "Tom"), new JProperty("Age", 44), new JProperty("Department", "Personnel Department"))));
            Console.WriteLine(staff.ToString());

            con("--------------------2.创建JSON数组----------------------------");
            JArray jArr = new JArray();
            jArr.Add(new JValue("fsd1"));
            jArr.Add(new JValue("fsd2"));
            jArr.Add(new JValue("fsd3"));
            jArr.Add(new JValue("fsd4"));
            jArr.Add(new JValue("fsd5"));
            con(jArr.ToString());
            con("--------------------2.创建JSON数组-示例---------------------------");
            JArray arr = new JArray();
            arr.Add(new JValue(1));
            arr.Add(new JValue(2));
            arr.Add(new JValue(3));
            Console.WriteLine(arr.ToString());

            con("-------------三.使用Linq to JSON----------");
            string json = "{\"Name\" : \"Jack\", \"Age\" : 34, \"Colleagues\" : [{\"Name\" : \"Nancy\",\"Age\":18},{\"Name\" : \"Tom\" , \"Age\":44},{\"Name\" : \"Abel\",\"Age\":29}] }";

            con("------------①获取该员工的姓名----------");



            JObject jobj = JObject.Parse(json);

            var name = jobj["Name"].ToString();
            con(name);

            con("-------------②获取该员工同事的所有姓名-----------------");

            var aa = from na in jobj["Colleagues"].Children()
                     select na["Name"];
            foreach (var item in aa)
            {
                con(item.ToString());

            }

            List<JToken> jTlst = jobj["Colleagues"].Children().Select(j => j["Name"]).ToList();
            jTlst.ForEach(x => con(x.ToString()));
            con("-------------②现在我们发现Jack的同事Tom的年龄错了，应该为45---------");

            var vv = jobj.SelectToken("Colleagues").Where(x => x["Name"].ToString() == "Tom").ToList();

            vv.First()["Age"] = 1001;
            vv.Remove("Name");
            con(jobj.ToString());






            Console.ReadKey();




        }



    }
}
