using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeData
{
    public class DataLogic
    {
        public int Add(Manage_Type model)
        {
            using (var conn = DapperConnection.GetConnection())
            {
                string sql = $"Insert into Manage_Type (Id,Path) Values ('{model.Id}','{model.Path}')";
                return conn.Execute(sql);
            }
        }

        public int Add1(Manage_Type model)
        {
            using (var conn = DapperConnection.GetConnection())
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@Id", model.Id);
                dp.Add("@AdminAccount", model.AdminAccount);
                dp.Add("@AdminName", model.AdminName);
                dp.Add("@ApproverAccount", model.ApproverAccount);
                dp.Add("@ApproverName", model.ApproverName);
                dp.Add("@CreateDate", model.CreateDate);
                dp.Add("@CreateUser", model.CreateUser);
                dp.Add("@IsValid", model.IsValid);
                dp.Add("@OrderNo", model.OrderNo);
                dp.Add("@ParentId", model.ParentId);
                dp.Add("@Path", model.Path);
                dp.Add("@Remark", model.Remark);
                dp.Add("@TypeCode", model.TypeCode);
                dp.Add("@TypeName", model.TypeName);
                dp.Add("@UpdateDate", model.UpdateDate);
                dp.Add("@UpdateUser", model.UpdateUser);


                return conn.Execute("Manage_Type", dp, null, null, CommandType.TableDirect);
            }
        }
        public IEnumerable<Manage_Type> GetModels()
        {
            using (var conn = DapperConnection.GetConnection())
            {
                var sql = "Select * from Manage_Type";
                return conn.Query<Manage_Type>(sql).ToList();
            }
        }
    }
}
