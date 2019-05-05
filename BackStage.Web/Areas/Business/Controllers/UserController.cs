using Infrastructure;
using Opcomunity.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class UserController : BaseController
    {
        // GET: Business/User
        public ActionResult Index()
        {
            return View();
        }

        // GET: Business/Anchor
        public JsonResult GetList(int pageIndex, int pageSize,string condition, string channel)
        {
            var service = Ioc.Get<IUserService>();
            var data = service.GetUserList(pageIndex,pageSize,condition, channel);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetBlackUser(long userId)
        {
            if (userId <= 0)
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IUserService>();
            var result = service.SetBlackUser(userId);
            string message = "";
            if (result)
                message = "用户已拉黑";
            else
                message = "用户信息错误";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        // GET: Business/User
        public ActionResult Coin()
        {
            return View();
        }

        // GET: Business/Anchor
        public JsonResult GetCoinList(int pageIndex, int pageSize, string condition)
        {
            var service = Ioc.Get<IUserService>();
            var data = service.GetUserCoinList(pageIndex, pageSize, condition);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Business/User
        public ActionResult CoinJournal()
        {
            return View();
        }

        // GET: Business/Anchor
        public JsonResult GetCoinJournalList(long userId, int pageIndex, int pageSize)
        {
            var service = Ioc.Get<IUserService>();
            var data = service.GetUserCoinJournalList(userId,pageIndex, pageSize);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // GET: Business/User
        public ActionResult IncomeJournal()
        {
            return View();
        }

        // GET: Business/Anchor
        public JsonResult GetIncomeJournalList(long userId, int pageIndex, int pageSize, string condition)
        {
            var service = Ioc.Get<IUserService>();
            var data = service.GetUserIncomeJournalList(userId,pageIndex, pageSize, condition);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Business/User
        public ActionResult Bind()
        {
            return View();
        }

        // GET: Business/Anchor
        public JsonResult GetBindUserList(long userId, string condition)
        {
            var service = Ioc.Get<IUserService>();
            var data = service.GetBindUserList(userId,condition);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult EditBind()
        {
            return View();
        }

        public JsonResult InitEditBind(string id)
        {
            var iId = TypeHelper.TryParse(id, 0L); 
            if (iId <= 0)
                return Json(null, JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IUserService>();
            var data = service.GetBindUserModel(iId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveInviteUser(long id, int cost, int cashout)
        {
            if (id <= 0 || cost <= 0 || cashout <= 0)
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IUserService>();
            var result = service.SaveInviteUser(id, cost, cashout);
            string message = "";
            if (result)
                message = "提交成功";
            else
                message = "信息错误";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddInviteUser(long userId, long newUserId)
        {
            if (userId <= 0 || newUserId <= 0)
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            if(userId == newUserId)
                return Json("不能添加自己为邀请用户", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IUserService>();
            var message = service.AddInviteUser(userId, newUserId);  
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}