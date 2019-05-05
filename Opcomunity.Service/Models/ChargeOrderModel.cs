using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class ChargeOrderModel
    {
        public string OrderId { get; set; }
        public long UserId { get; set; }
        public string NickName { get; set; }
        public string PhoneNo { get; set; }
        public string ChargeType { get; set; }
        public decimal ChargeMoney { get; set; }
        public int ExchargeRate { get; set; }
        public int CoinCount { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public string Ip { get; set; }
        public System.DateTime TakeOrderTime { get; set; }
        public Nullable<System.DateTime> ChargeTime { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
