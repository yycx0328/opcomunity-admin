﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Models
{
    public class GiftTransactionModel
    {
        public long UserId { get; set; }
        public string NickName { get; set; }
        public string PhoneNo { get; set; }
        public long AnchorId { get; set; }
        public string AnchorNickName { get; set; }
        public string AnchorPhoneNo { get; set; }
        public string GiftName { get; set; }
        public int OriginalPrice { get; set; }
        public int CostPrice { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public string Ip { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
