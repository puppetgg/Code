using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHCURT
{
    public class Manage_Type
    {
        public virtual string Id { get; set; } = Guid.NewGuid().ToString();
        public virtual string TypeName { get; set; }
        public virtual string TypeCode { get; set; } = "YMTC";
        public virtual string ParentId { get; set; }
        public virtual string Path { get; set; }

        public virtual string AdminName { get; set; }
        public virtual string AdminAccount { get; set; }
        public virtual string ApproverName { get; set; }
        public virtual string ApproverAccount { get; set; }
        public virtual int OrderNo { get; set; }

        public virtual string Remark { get; set; }
        public virtual byte IsValid { get; set; } = (byte)'1';
        public virtual DateTime CreateDate { get; set; } = DateTime.Now;
        public virtual DateTime UpdateDate { get; set; } = DateTime.Now;
        public virtual string CreateUser { get; set; }
        public virtual string UpdateUser { get; set; }

    }
}
