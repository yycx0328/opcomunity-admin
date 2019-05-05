using Infrastructure;
using Opcomunity.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Opcomunity.Data;
using Opcomunity.Service.Models;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class StatisticsController : BaseController
    { 
        public ActionResult Charge()
        {
            return View();
        }

        // GET: Business/Statistics
        public JsonResult GetChargeStatistics(string startDate, string endDate)
        {
            var service = Ioc.Get<IStatisticsService>();
            DateTime dtStart, dtEnd;
            if(!DateTime.TryParse(startDate, out dtStart) || !DateTime.TryParse(endDate,out dtEnd))
            {
                //return Json(new { state = 1000, message = "日期格式错误" }, JsonRequestBehavior.AllowGet);
                return Json("日期格式错误", JsonRequestBehavior.AllowGet);
            }
            var list = service.GetChargeStatistics(dtStart, dtEnd);
            //return Json(new { state = 0, message = "成功", data = list }, JsonRequestBehavior.AllowGet);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CallTimes()
        {
            return View();
        }

        // GET: Business/Statistics
        public JsonResult GetCallTimesStatistics(string startDate, string endDate)
        {
            var service = Ioc.Get<IStatisticsService>();
            DateTime dtStart, dtEnd;
            if (!DateTime.TryParse(startDate, out dtStart) || !DateTime.TryParse(endDate, out dtEnd))
            {
                return Json("日期格式错误", JsonRequestBehavior.AllowGet);
            }
            var list = service.GetCallTimesStatistics(dtStart, dtEnd);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cash()
        {
            return View();
        }

        // GET: Business/Statistics
        public JsonResult GetCashStatistics(string startDate, string endDate)
        {
            var service = Ioc.Get<IStatisticsService>();
            DateTime dtStart, dtEnd;
            if (!DateTime.TryParse(startDate, out dtStart) || !DateTime.TryParse(endDate, out dtEnd))
            {
                return Json("日期格式错误", JsonRequestBehavior.AllowGet);
            }
            var list = service.GetCashStatistics(dtStart, dtEnd);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Coin()
        {
            return View();
        }

        // GET: Business/Statistics
        public JsonResult GetCoinStatistics(string startDate, string endDate)
        {
            var service = Ioc.Get<IStatisticsService>();
            DateTime dtStart, dtEnd;
            if (!DateTime.TryParse(startDate, out dtStart) || !DateTime.TryParse(endDate, out dtEnd))
            {
                return Json("日期格式错误", JsonRequestBehavior.AllowGet);
            }
            var list = service.GetCoinStatistics(dtStart, dtEnd);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NeteaseCall()
        {
            return View();
        }

        // GET: Business/Statistics
        public JsonResult GetNeteaseCallStatistics(string startDate, string endDate)
        {
            var service = Ioc.Get<IStatisticsService>();
            DateTime dtStart, dtEnd;
            if (!DateTime.TryParse(startDate, out dtStart) || !DateTime.TryParse(endDate, out dtEnd))
            {
                return Json("日期格式错误", JsonRequestBehavior.AllowGet);
            }
            var list = service.GetNeteaseCallStatistics(dtStart, dtEnd);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}