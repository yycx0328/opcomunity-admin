using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class UserCoinJournalModel
    {
        public long UserId { get; set; }
        public long CoinCount { get; set; }
        public long CurrentCount { get; set; }
        public string IOStatus { get; set; }
        public int JournalType { get; set; }
        public string JournalDesc { get; set; }
        public string Ip { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
