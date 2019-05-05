using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class InviteUserModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string PhoneNo { get; set; }
        public long NewUserId { get; set; }
        public string NickName { get; set; }
        public int CostAwardRate { get; set; }
        public int CashoutAwardRate { get; set; }
        public DateTime InviteTime { get; set; }
    }
}
