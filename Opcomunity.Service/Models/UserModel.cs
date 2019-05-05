using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class UserModel
    {
        public long UserId { get; set; }
        public string NickName { get; set; }
        public string PhoneNo { get; set; }
        public string Description { get; set; }
        public string Ip { get; set; }
        public Nullable<int> Channel { get; set; }
        public bool IsLegal { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime LastLoginTime { get; set; }
    }
}
