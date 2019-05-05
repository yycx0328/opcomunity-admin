using Opcomunity.Data.Entities;
using Opcomunity.Service.Interface;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Opcomunity.Service.Implementations
{
    public class ChannelService : ServiceBase, IChannelService
    {
        public bool EditChannel(int id, string description, bool isAvailable)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_Channel
                            where c.Id == id
                            select c;
                var model = query.SingleOrDefault();
                if(model!=null)
                {
                    model.Description = description;
                    model.IsAvailable = isAvailable;
                }
                else
                {
                    model = new TB_Channel {
                        Id = id,
                        Description = description,
                        IsAvailable = isAvailable,
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now
                    };
                    context.TB_Channel.Add(model);
                }
                context.SaveChanges();
                return true;
            }
        }

        public List<TB_AdmUserChannel> GetAdmUserChannel(int userId)
        {
            using (var context = base.NewContext())
            {
                var query = from a in context.TB_AdmUserChannel
                            where a.AdmUserId == userId
                            select a;
                return query.ToList();
            }
        }

        public TB_Channel GetChannelById(int id)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_Channel
                            where c.IsAvailable && c.Id == id
                            select c;
                return query.SingleOrDefault();
            }
        }

        public List<TB_Channel> GetChannelList(int pageIndex, int pageSize, string channel)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_Channel
                            where c.IsAvailable
                            select c;
                if (!string.IsNullOrEmpty(channel))
                {
                    var channelId = TypeHelper.TryParse(channel, 0);
                    query = query.Where(p => p.Id == channelId);
                }
                return query.OrderBy(p=>p.Id).Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public bool SaveAdmUserChannel(int userId, int channel, int deduction)
        {
            using (var context = base.NewContext())
            {
                var query = from a in context.TB_AdmUserChannel
                            where a.AdmUserId == userId && a.ChannelId == channel
                            select a;
                var model = query.SingleOrDefault();
                if(model!=null)
                {
                    model.Deduction = deduction;
                }
                else
                {
                    model = new TB_AdmUserChannel()
                    {
                        AdmUserId = userId,
                        ChannelId = channel,
                        Deduction = deduction,
                        CreateTime = DateTime.Now
                    };
                    context.TB_AdmUserChannel.Add(model);
                }
                context.SaveChanges();
                return true;
            }
        }

        public List<ChannelUserModel> GetChannelUserStatistics(DateTime beginDate, DateTime endDate, int admUserId, string channel)
        {
            using (var context = base.NewContext())
            {
                var query = from s in context.TB_StatisticsChannelUser
                            join c in context.TB_AdmUserChannel
                            on s.Channel equals c.ChannelId
                            where s.Date >= beginDate && s.Date <= endDate
                            && c.AdmUserId == admUserId
                            orderby s.Date descending
                            select new ChannelUserModel
                            {
                                Date = s.Date,
                                Channel = s.Channel,
                                RegistCount = s.RegistCount,
                                ChargeMoney = s.ChargeMoney,
                                ChargeUserCount = s.ChargeUserCount ?? 0,
                                CoinChargeMoney = s.CoinChargeMoney ?? 0,
                                CoinChargeUserCount = s.CoinChargeUserCount ?? 0,
                                VIPChargeMoney = s.VIPChargeMoney ?? 0,
                                VIPChargeUserCount = s.VIPChargeUserCount ?? 0,
                                TicketChargeMoney = s.TicketChargeMoney ?? 0,
                                TicketChargeUserCount = s.TicketChargeUserCount ?? 0,
                                ChatUserCount = s.ChatUserCount ?? 0,
                                Deduction = c.Deduction,
                                AvaChargeMoney = s.RegistCount == 0 || c.Deduction >= 100 ? 0.0 : (s.ChargeMoney * 1.0 / s.RegistCount) * (100 - c.Deduction) / 100
                            };
                if (!string.IsNullOrEmpty(channel))
                    return query.Where(p => p.Channel.ToString() == channel).ToList();
                return query.ToList();
            }
        }

        public List<int> GetAdmUserChannelList(int admUserId)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_AdmUserChannel
                            where c.AdmUserId == admUserId
                            select c.ChannelId;
                return query.ToList();
            }
        }
    }
}
