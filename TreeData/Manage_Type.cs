using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeData
{
    public class Manage_Type
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TypeName { get; set; }
        public string TypeCode { get; set; } = "YMTC";
        public string ParentId { get; set; }
        public string Path { get; set; }

        public string AdminName { get; set; }
        public string AdminAccount { get; set; }
        public string ApproverName { get; set; }
        public string ApproverAccount { get; set; }
        public int OrderNo { get; set; }

        public string Remark { get; set; }
        public byte IsValid { get; set; } = (byte)'1';
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }

    }
}
