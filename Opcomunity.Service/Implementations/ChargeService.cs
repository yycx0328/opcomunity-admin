using Opcomunity.Service.Interface;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Opcomunity.Service.Implementations
{
    public class ChargeService : ServiceBase, IChargeService
    {
        public List<ChargeOrderModel> GetList(int pageIndex, int pageSize, string condition, string status)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_OrderCharge
                            join u in context.TB_User
                            on c.UserId equals u.Id
                            orderby c.TakeOrderTime descending
                            select new ChargeOrderModel
                            {
                                OrderId = c.OrderId,
                                UserId = c.UserId,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                ChargeType = c.ChargeType,
                                ChargeMoney = c.ChargeMoney,
                                ExchargeRate = c.ExchargeRate,
                                CoinCount = c.CoinCount,
                                Status = c.Status,
                                StatusDescription = c.StatusDescription,
                                Ip = c.Ip,
                                TakeOrderTime = c.TakeOrderTime,
                                ChargeTime = c.ChargeTime, 
                                UpdateTime = c.UpdateTime
                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.UserId.ToString().Contains(condition) || p.NickName.Contains(condition)
                        || p.PhoneNo.Contains(condition));
                if (!string.IsNullOrEmpty(status))
                {
                    var intStatus = TypeHelper.TryParse(status, 0);
                    query = query.Where(p => p.Status == intStatus);
                }
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }
    }
}