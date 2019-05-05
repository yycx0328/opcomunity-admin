using Infrastructure;
using Opcomunity.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class CallController : BaseController
    {
        // GET: Business/Cash
        public ActionResult UnConnect()
        {
            return View();
        }

        // GET: Business/Cash
        public JsonResult GetUnConnectList(int pageIndex, int pageSize, string condition)
        {
            var service = Ioc.Get<ILiveCallService>();
            var data = service.GetUnConnectList(pageIndex, pageSize, condition);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Business/Cash
        public ActionResult Connect()
        {
            return View();
        }

        // GET: Business/Cash
        public JsonResult GetConnectList(int pageIndex, int pageSize, string condition)
        {
            var service = Ioc.Get<ILiveCallService>();
            var data = service.GetConnectList(pageIndex, pageSize, condition);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Business/Cash
        public ActionResult ChatText()
        {
            return View();
        }

        // GET: Business/Cash
        public JsonResult GetChatText(int pageIndex, int pageSize, string f_condition, string t_condition)
        {
            var service = Ioc.Get<ILiveCallService>();
            var data = service.GetTextList(pageIndex, pageSize, f_condition, t_condition);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}