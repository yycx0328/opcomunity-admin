using Infrastructure;
using Opcomunity.Service.Interface;
using Opcomunity.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class ChannelController : BaseController
    {
        // GET: Business/Channel

        public BackStage.Service.Abstracts.IUserService userService {get;set;}
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetChannelList(int pageIndex, int pageSize, string channel)
        {
            var service = Ioc.Get<IChannelService>();
            var data = service.GetChannelList(pageIndex, pageSize, channel);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public JsonResult InitEdit(string Id)
        {
            var id = TypeHelper.TryParse(Id, 0);
            if (id <= 0)
                return Json(null, JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IChannelService>();
            var data = service.GetChannelById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(int id, string description, bool isAvailable)
        {
            if (id <= 0 || string.IsNullOrEmpty(description))
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IChannelService>();
            var result = service.EditChannel(id, description, isAvailable);
            string message = "";
            if (result)
                message = "提交成功";
            else
                message = "主播信息错误";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdmUserList()
        {
            return View();
        }

        public JsonResult GetAdmUserList(string condition)
        {
            List<Service.Dto.UserDto> list;
            if(!string.IsNullOrEmpty(condition))
                list = userService.Query(p => !p.IsDeleted && (p.LoginName.Contains(condition) || p.RealName.Contains(condition)), p => p.Id, false);
            else
                list = userService.Query(p => !p.IsDeleted, p => p.Id, false);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UsersChannel()
        {
            return View();
        }

        public JsonResult GetUsersChannel(int userId)
        {
            var service = Ioc.Get<IChannelService>();
            var list = service.GetAdmUserChannel(userId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AdmUserChannel()
        {
            return View();
        }

        public JsonResult GetAdmUserChannel(int userId)
        {
            var service = Ioc.Get<IChannelService>();
            var list = service.GetAdmUserChannel(userId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveAdmUserChannel(int id, int channel, int deduction)
        {
            if (id <= 0 || channel<=0 || deduction<0)
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IChannelService>();
            var result = service.SaveAdmUserChannel(id, channel, deduction);
            string message = "";
            if (result)
                message = "提交成功";
            else
                message = "添加失败";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChannelUser()
        {
            return View();
        }

        public JsonResult GetMyChannels()
        {
            if (CurrentUser == null)
                return Json(null, JsonRequestBehavior.AllowGet);

            var service = Ioc.Get<IChannelService>();
            var list = service.GetAdmUserChannelList(CurrentUser.Id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserChannels(int userId)
        {
            if (CurrentUser == null)
                return Json(null, JsonRequestBehavior.AllowGet);

            var service = Ioc.Get<IChannelService>();
            var list = service.GetAdmUserChannelList(userId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMyChannelStatistics(string startDate, string endDate, string channel)
        {
            if (CurrentUser == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IChannelService>();
            DateTime dtStart, dtEnd;
            if (!DateTime.TryParse(startDate, out dtStart) || !DateTime.TryParse(endDate, out dtEnd))
            {
                return Json("日期格式错误", JsonRequestBehavior.AllowGet);
            }
            var list = service.GetChannelUserStatistics(dtStart, dtEnd, CurrentUser.Id, channel);
            if (list != null && list.Count > 0)
            {
                var a = list.Sum(p => p.RegistCount);
                var b = list.Sum(p => p.ChargeMoney);
                var c = list.Average(p => p.AvaChargeMoney);
                var model = new ChannelUserModel()
                {
                    Date = default(DateTime),
                    Channel = 0,
                    RegistCount = list.Sum(p => p.RegistCount),
                    ChargeMoney = list.Sum(p => p.ChargeMoney),
                    ChargeUserCount = list.Sum(p=>p.ChargeUserCount),
                    CoinChargeMoney = list.Sum(p => p.CoinChargeMoney),
                    CoinChargeUserCount = list.Sum(p => p.CoinChargeUserCount),
                    VIPChargeMoney = list.Sum(p => p.VIPChargeMoney),
                    VIPChargeUserCount = list.Sum(p => p.VIPChargeUserCount),
                    TicketChargeMoney = list.Sum(p => p.TicketChargeMoney),
                    TicketChargeUserCount = list.Sum(p => p.TicketChargeUserCount),
                    ChatUserCount = list.Sum(p => p.ChatUserCount),
                    AvaChargeMoney = list.Average(p => p.AvaChargeMoney)
                };
                list.Add(model);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChannelUserStatistics(string startDate, string endDate,int userId, string channel)
        {
            if (CurrentUser == null)
                return Json(null, JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IChannelService>();
            DateTime dtStart, dtEnd;
            if (!DateTime.TryParse(startDate, out dtStart) || !DateTime.TryParse(endDate, out dtEnd))
            {
                return Json("日期格式错误", JsonRequestBehavior.AllowGet);
            }
            var list = service.GetChannelUserStatistics(dtStart, dtEnd, userId, channel);
            if (list != null && list.Count > 0)
            {
                var a = list.Sum(p => p.RegistCount);
                var b = list.Sum(p => p.ChargeMoney);
                var c = list.Average(p => p.AvaChargeMoney);
                var model = new ChannelUserModel()
                {
                    Date = default(DateTime),
                    Channel = 0,
                    RegistCount = list.Sum(p => p.RegistCount),
                    ChargeMoney = list.Sum(p => p.ChargeMoney),
                    ChargeUserCount = list.Sum(p => p.ChargeUserCount),
                    CoinChargeMoney = list.Sum(p => p.CoinChargeMoney),
                    CoinChargeUserCount = list.Sum(p => p.CoinChargeUserCount),
                    VIPChargeMoney = list.Sum(p => p.VIPChargeMoney),
                    VIPChargeUserCount = list.Sum(p => p.VIPChargeUserCount),
                    TicketChargeMoney = list.Sum(p => p.TicketChargeMoney),
                    TicketChargeUserCount = list.Sum(p => p.TicketChargeUserCount),
                    ChatUserCount = list.Sum(p => p.ChatUserCount),
                    AvaChargeMoney = list.Average(p => p.AvaChargeMoney)
                };
                list.Add(model);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}