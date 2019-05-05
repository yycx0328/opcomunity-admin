using Opcomunity.Service.Interface;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Opcomunity.Services;

namespace Opcomunity.Service.Implementations
{
    public class CashOutService : ServiceBase, ICashOutService
    {
        public CashOutTransactionModel GetDetail(string id)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_CashTransaction
                            join u in context.TB_User
                            on c.UserId equals u.Id
                            where c.Id == id
                            select new CashOutTransactionModel
                            {
                                Id = c.Id,
                                UserId = c.UserId,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                CashMoney = c.CashMoney,
                                CashRatio = c.CashRatio,
                                CoinCount = c.CoinCount,
                                CashName = c.CashName,
                                CashAccount = c.CashAccount,
                                Status = c.Status,
                                StatusDescription = c.StatusDescription,
                                CashTime = c.CashTime,
                                Ip = c.Ip,
                                UpdateDate = c.UpdateDate
                            };
                return query.SingleOrDefault();
            }
        }

        public List<CashOutTransactionModel> GetList(int pageIndex, int pageSize,string condition, string status)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_CashTransaction
                            join u in context.TB_User
                            on c.UserId equals u.Id
                            orderby c.CashTime descending
                            select new CashOutTransactionModel
                            {
                                Id = c.Id,
                                UserId = c.UserId,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                CashMoney = c.CashMoney,
                                CashRatio = c.CashRatio,
                                CoinCount = c.CoinCount,
                                CashName = c.CashName,
                                CashAccount = c.CashAccount,
                                Status = c.Status,
                                StatusDescription = c.StatusDescription,
                                CashTime = c.CashTime,
                                Ip = c.Ip,
                                UpdateDate = c.UpdateDate
                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.UserId.ToString().Contains(condition) || p.NickName.Contains(condition) 
                        || p.PhoneNo.Contains(condition) || p.CashName.Contains(condition) || p.CashAccount.Contains(condition));
                if (!string.IsNullOrEmpty(status))
                {
                    var intStatus = TypeHelper.TryParse(status, 0);
                    query = query.Where(p => p.Status == intStatus);
                }
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public bool UpdateStatus(string transactionId, CashStatusConfig cashStatus)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_CashTransaction
                            where c.Id == transactionId
                            select c;
                var cashModel = query.SingleOrDefault();
                if (cashModel != null)
                {
                    cashModel.Status = (int)cashStatus;
                    cashModel.StatusDescription = cashStatus.GetRemark();
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
