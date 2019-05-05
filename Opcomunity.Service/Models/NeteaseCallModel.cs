using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class NeteaseCallModel
    {
        public long UserId { get; set; }
        public string NickName { get; set; }
        public string PhoneNo { get; set; }
        public long AnchorId { get; set; }
        public string AnchorNickName { get; set; }
        public string AnchorPhoneNo { get; set; } 
        public int Duration { get; set; }
        public int CallRatio { get; set; }
        public int TotalFee { get; set; }
        public int ActualTransferFee { get; set; }
        public long CallTime { get; set; } 
        public System.DateTime CreateTime { get; set; }
    }
}
