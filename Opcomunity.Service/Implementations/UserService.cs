using Opcomunity.Data.Entities;
using Opcomunity.Service.Interface;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Opcomunity.Service.Implementations
{
    public class UserService : ServiceBase, IUserService
    {
        public List<UserCoinModel> GetUserCoinList(int pageIndex, int pageSize, string condition)
        {
            using (var context = base.NewContext())
            {
                var query = from uc in context.TB_UserCoin
                            join u in context.TB_User
                            on uc.UserId equals u.Id
                            orderby u.Id descending
                            select new UserCoinModel
                            {
                                UserId = uc.UserId,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                CurrentCoin = uc.CurrentCoin,
                                CurrentIncome = uc.CurrentIncome
                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.UserId.ToString().Contains(condition) || p.NickName.Contains(condition) || p.PhoneNo.Contains(condition));
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public List<UserIncomeJournalModel> GetUserIncomeJournalList(long userId,int pageIndex, int pageSize, string condition)
        {
            using (var context = base.NewContext())
            {
                var query = from j in context.TB_UserIncomeJournal
                            join u in context.TB_User
                            on j.OriginUserId equals u.Id
                            into g from u in g.DefaultIfEmpty()
                            where j.UserId == userId
                            orderby j.CreateTime descending
                            select new UserIncomeJournalModel
                            {
                                UserId = j.UserId,
                                OriginUserId = u == null?"": u.Id.ToString(),
                                NickName = u==null?"": u.NickName,
                                PhoneNo = u==null ?"": u.PhoneNo,
                                IncomeCount = j.IncomeCount,
                                CurrentCount = j.CurrentCount,
                                IOStatus = j.IOStatus,
                                JournalType = j.JournalType,
                                JournalDesc = j.JournalDesc,
                                Ip = j.Ip,
                                CreateTime = j.CreateTime

                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.OriginUserId.ToString().Contains(condition) || p.NickName.Contains(condition) || p.PhoneNo.Contains(condition));
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public List<UserCoinJournalModel> GetUserCoinJournalList(long userId, int pageIndex, int pageSize)
        {
            using (var context = base.NewContext())
            {
                var query = from j in context.TB_UserCoinJournal
                            where j.UserId == userId
                            orderby j.CreateTime descending
                            select new UserCoinJournalModel
                            {
                                UserId = j.UserId,
                                CoinCount = j.CoinCount,
                                CurrentCount = j.CurrentCount,
                                IOStatus = j.IOStatus,
                                JournalType = j.JournalType,
                                JournalDesc = j.JournalDesc,
                                Ip = j.Ip,
                                CreateTime = j.CreateTime
                            };
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public List<UserModel> GetUserList(int pageIndex, int pageSize,string condition, string channel)
        {
            using (var context = base.NewContext())
            {
                var query = from u in context.TB_User
                            join ua in context.TB_UserAuth
                            on u.Id equals ua.UserId
                            orderby u.Id descending
                            select new UserModel {
                                UserId = u.Id,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                Description = u.Description,
                                IsLegal = ua.IsLegal,
                                Channel = ua.Channel,
                                Ip = ua.Ip,
                                CreateTime = ua.CreateTime,
                                LastLoginTime = ua.LastLoginTime
                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.UserId.ToString().Contains(condition) || p.NickName.Contains(condition) || p.PhoneNo.Contains(condition));
                if (!string.IsNullOrEmpty(channel))
                {
                    var channelId = TypeHelper.TryParse(channel, 0);
                    query = query.Where(p => p.Channel == channelId);
                }
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public List<InviteUserModel> GetBindUserList(long userId, string condition)
        {
            using (var context = base.NewContext())
            {
                var query = from ui in context.TB_UserInvite
                            join u in context.TB_User
                            on ui.NewUserId equals u.Id
                            into g
                            from u in g.DefaultIfEmpty()
                            where ui.UserId == userId
                            orderby u.Id descending
                            select new InviteUserModel
                            {
                                Id = ui.Id,
                                UserId = ui.UserId,
                                PhoneNo = ui.PhoneNo,
                                NewUserId = u == null ? 0:u.Id,
                                NickName = u == null ? "" : u.NickName,
                                CostAwardRate = ui.CostAwardRate,
                                CashoutAwardRate = ui.CashoutAwardRate,
                                InviteTime = ui.InviteTime
                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.NewUserId.ToString().Contains(condition) || p.NickName.Contains(condition) || p.PhoneNo.Contains(condition));
                return query.ToList();
            }
        }

        public InviteUserModel GetBindUserModel(long id)
        {
            using (var context = base.NewContext())
            {
                var query = from ui in context.TB_UserInvite
                            where ui.Id == id
                            select new InviteUserModel
                            {
                                Id = ui.Id,
                                UserId = ui.UserId,
                                PhoneNo = ui.PhoneNo,
                                NewUserId = (long)ui.NewUserId,
                                CostAwardRate = ui.CostAwardRate,
                                CashoutAwardRate = ui.CashoutAwardRate,
                                InviteTime = ui.InviteTime
                            };
                return query.SingleOrDefault();
            }
        }

        public bool SaveInviteUser(long id, int cost, int cashout)
        {
            using (var context = base.NewContext())
            {
                var model = context.TB_UserInvite.SingleOrDefault(p => p.Id == id);
                if (model == null)
                    return false;
                model.CostAwardRate = cost;
                model.CashoutAwardRate = cashout;
                context.SaveChanges();
                return true;
            }
        }

        public string AddInviteUser(long userId, long newUserId)
        {
            using (var context = base.NewContext())
            {
                var model = context.TB_UserInvite.FirstOrDefault(p => p.NewUserId == newUserId);
                if(model!=null)
                {
                    if (model.UserId == userId)
                        return "当前用户已经绑定该用户";
                    else
                        return "该用户已被其他用户绑定";
                }
                var newUser = context.TB_User.SingleOrDefault(p => p.Id == newUserId);
                if (newUser == null)
                    return "要添加绑定的用户不存在";
                model = new TB_UserInvite()
                {
                    UserId = userId,
                    NewUserId = newUserId,
                    PhoneNo = newUser.PhoneNo,
                    CostAwardRate = 10,
                    CashoutAwardRate = 10,
                    Ip = WebUtils.GetClientIP(),
                    InviteTime = DateTime.Now
                };
                context.TB_UserInvite.Add(model);
                context.SaveChanges();
                return "提交成功";
            }
        }

        public bool SetBlackUser(long userId)
        {
            using (var context = base.NewContext())
            {
                var query = from u in context.TB_UserTokenInfo
                            where u.UserId == userId
                            select u;
                var token = query.SingleOrDefault();
                if (token == null)
                    return false;
                token.UserToken = "D";

                var qNetease = from u in context.TB_NeteaseAccount
                            where u.UserId == userId
                            select u;
                var netease = qNetease.SingleOrDefault();
                if (netease == null)
                    return false;
                netease.NeteaseToken = "D";

                context.SaveChanges();
                return true;
            }
        }
    }
}
