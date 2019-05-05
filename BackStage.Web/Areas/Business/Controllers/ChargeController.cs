using Infrastructure;
using Opcomunity.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class ChargeController : Controller
    {
        // GET: Business/Pay
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(int pageIndex, int pageSize, string condition, string status)
        {
            var service = Ioc.Get<IChargeService>();
            var data = service.GetList(pageIndex, pageSize, condition, status);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}