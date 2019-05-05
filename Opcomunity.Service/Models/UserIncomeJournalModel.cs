using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class UserIncomeJournalModel
    {
        public long UserId { get; set; }
        public string OriginUserId { get; set; }
        public string NickName { get; set; }
        public string PhoneNo { get; set; }
        public long IncomeCount { get; set; }
        public long CurrentCount { get; set; }
        public string IOStatus { get; set; }
        public int JournalType { get; set; }
        public string JournalDesc { get; set; }
        public string Ip { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
