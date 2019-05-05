using System;
using System.Collections.Generic;

namespace Opcomunity.Data.Entities
{
    public partial class TB_StatisticsChannelUser
    {
        public System.DateTime Date { get; set; }
        public int Channel { get; set; }
        public int RegistCount { get; set; }
        public int ChargeMoney { get; set; }
        public Nullable<int> ChargeUserCount { get; set; }
        public Nullable<int> CoinChargeMoney { get; set; }
        public Nullable<int> CoinChargeUserCount { get; set; }
        public Nullable<int> VIPChargeMoney { get; set; }
        public Nullable<int> VIPChargeUserCount { get; set; }
        public Nullable<int> TicketChargeMoney { get; set; }
        public Nullable<int> TicketChargeUserCount { get; set; }
        public Nullable<int> ChatUserCount { get; set; }
    }
}
