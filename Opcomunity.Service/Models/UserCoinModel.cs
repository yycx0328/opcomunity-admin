using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class UserCoinModel
    {
        public long UserId { get; set; }
        public string NickName { get; set; }
        public string PhoneNo { get; set; }
        public long CurrentCoin { get; set; }
        public long CurrentIncome { get; set; }
    }
}
