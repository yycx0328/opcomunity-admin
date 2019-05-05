using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class CashOutTransactionModel
    {
        public string Id { get; set; }
        public long UserId { get; set; }
        public string NickName { get; set; }
        public string PhoneNo { get; set; }
        public int CoinCount { get; set; }
        public int CashMoney { get; set; }
        public int CashRatio { get; set; }
        public string CashAccount { get; set; }
        public string CashName { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public System.DateTime CashTime { get; set; }
        public string Ip { get; set; }
        public System.DateTime UpdateDate { get; set; }
    }
}
