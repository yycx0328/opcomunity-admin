using Opcomunity.Service.Interface;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opcomunity.Service.Implementations
{
    public class GitService : ServiceBase, IGiftService
    {
        public List<GiftTransactionModel> GetTrasactionList(int pageIndex, int pageSize, string condition)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_GiftTransaction
                            join u in context.TB_User
                            on c.UserId equals u.Id
                            join a in context.TB_User
                            on c.AnchorId equals a.Id
                            join g in context.TB_Gift
                            on c.GiftId equals g.Id
                            orderby c.CreateTime descending
                            select new GiftTransactionModel
                            {
                                UserId = c.UserId,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                AnchorId = c.AnchorId,
                                AnchorNickName = a.NickName,
                                AnchorPhoneNo = a.PhoneNo,
                                GiftName = g.Name,
                                CostPrice = c.CostPrice,
                                OriginalPrice = c.OriginalPrice,
                                Ip = c.Ip,
                                Status = c.Status,
                                StatusDescription = c.StatusDescription,
                                CreateTime = c.CreateTime
                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.UserId.ToString().Contains(condition) || p.NickName.Contains(condition)
                        || p.PhoneNo.Contains(condition) || p.AnchorId.ToString().Contains(condition)
                        || p.AnchorNickName.Contains(condition) || p.AnchorPhoneNo.Contains(condition)); 
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }
    }
}
