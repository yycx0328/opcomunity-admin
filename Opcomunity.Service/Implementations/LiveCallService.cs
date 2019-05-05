using Opcomunity.Service.Interface;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Opcomunity.Service.Implementations
{
    public class LiveCallService : ServiceBase, ILiveCallService
    {
        public List<NeteaseCallModel> GetConnectList(int pageIndex, int pageSize, string condition)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_NeteaseCall
                            join u in context.TB_User
                            on c.CallerId equals u.Id
                            join a in context.TB_User
                            on c.AnchorId equals a.Id
                            orderby c.CreateTime descending
                            select new NeteaseCallModel
                            {
                                UserId = c.CallerId,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                AnchorId = c.AnchorId,
                                AnchorNickName = a.NickName,
                                AnchorPhoneNo = a.PhoneNo,
                                Duration = c.Duration,
                                CallRatio = c.CallRatio,
                                TotalFee = c.TotalFee,
                                ActualTransferFee = c.ActualTransferFee,
                                CallTime = c.CallTime,
                                CreateTime = c.CreateTime
                            };
                if (!string.IsNullOrEmpty(condition))
                    query = query.Where(p => p.UserId.ToString().Contains(condition) || p.NickName.Contains(condition)
                        || p.PhoneNo.Contains(condition) || p.AnchorId.ToString().Contains(condition)
                        || p.AnchorNickName.Contains(condition) || p.AnchorPhoneNo.Contains(condition));
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public List<NeteaseTextModel> GetTextList(int pageIndex, int pageSize, string f_condition,string t_condition)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_NeteaseText
                            join tu in context.TB_User
                            on c.ToUserId equals tu.Id
                            orderby c.MsgTimestamp descending
                            select new NeteaseTextModel
                            {
                                Id = c.Id,
                                Body = c.Body,
                                ConvType = c.ConvType,
                                CreateTime = c.CreateTime,
                                EventType = c.EventType,
                                FromAccount = c.FromAccount,
                                FromClientType = c.FromClientType,
                                FromDeviceId = c.FromDeviceId,
                                FromNick = c.FromNick,
                                FromUserId = c.FromUserId,
                                MsgIdClient = c.MsgIdClient,
                                MsgIdServer = c.MsgIdServer,
                                MsgType = c.MsgType,
                                MsgTimestamp = c.MsgTimestamp,
                                ResendFlag = c.ResendFlag,
                                ToAccount = c.ToAccount,
                                ToNick = tu.NickName,
                                ToUserId = c.ToUserId
                            };
                if (!string.IsNullOrEmpty(f_condition))
                    query = query.Where(p => p.FromNick.ToString().Contains(f_condition) || p.FromUserId.ToString().Contains(f_condition));
                if (!string.IsNullOrEmpty(t_condition))
                    query = query.Where(p => p.ToNick.ToString().Contains(t_condition) || p.ToUserId.ToString().Contains(t_condition));
                return query.Take(pageSize * pageIndex).Skip(pageSize * (pageIndex - 1)).ToList();
            }
        }

        public List<CallAnchorModel> GetUnConnectList(int pageIndex, int pageSize, string condition)
        {
            using (var context = base.NewContext())
            {
                var query = from c in context.TB_CallAnchor
                            join u in context.TB_User
                            on c.UserId equals u.Id
                            join a in context.TB_User
                            on c.AnchorId equals a.Id
                            orderby c.CreateTime descending
                            select new CallAnchorModel
                            {
                                Id = c.Id,
                                UserId = c.UserId,
                                NickName = u.NickName,
                                PhoneNo = u.PhoneNo,
                                AnchorId = c.AnchorId,
                                AnchorNickName = a.NickName,
                                AnchorPhoneNo = a.PhoneNo,
                                Ip = c.Ip,
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
