using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class ChannelUserModel
    {
        public DateTime Date { get; set; }
        public int Channel { get; set; }
        public int RegistCount { get; set; }
        public int ChargeMoney { get; set; }
        public int ChargeUserCount { get; set; }
        public int CoinChargeMoney { get; set; }
        public int CoinChargeUserCount { get; set; }
        public int VIPChargeMoney { get; set; }
        public int VIPChargeUserCount { get; set; }
        public int TicketChargeMoney { get; set; }
        public int TicketChargeUserCount { get; set; }
        public int ChatUserCount { get; set; }
        public int Deduction { get; set; }
        public double AvaChargeMoney { get; set; }
    }
}
