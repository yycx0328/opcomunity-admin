using Infrastructure;
using Opcomunity.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class GiftController : Controller
    {
        // GET: Business/Cash
        public ActionResult Trasaction()
        {
            return View();
        }

        // GET: Business/Cash
        public JsonResult GetTrasactionList(int pageIndex, int pageSize, string condition)
        {
            var service = Ioc.Get<IGiftService>();
            var data = service.GetTrasactionList(pageIndex, pageSize, condition);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}