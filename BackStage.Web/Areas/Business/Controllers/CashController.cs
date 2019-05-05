using Infrastructure;
using Opcomunity.Service.Interface;
using Opcomunity.Services;
using System.Web.Mvc;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class CashController : Controller
    {
        // GET: Business/Cash
        public ActionResult Index()
        {
            return View();
        }

        // GET: Business/Cash
        public JsonResult GetList(int pageIndex, int pageSize, string condition, string status)
        {
            var service = Ioc.Get<ICashOutService>();
            var data = service.GetList(pageIndex, pageSize, condition, status);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Business/Cash
        public ActionResult Proc()
        {
            return View();
        }

        // GET: Business/Cash
        public JsonResult GetDetail(string transactionId)
        {
            var service = Ioc.Get<ICashOutService>();
            var data = service.GetDetail(transactionId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(string transactionId)
        {
            var service = Ioc.Get<ICashOutService>();
            var result = service.UpdateStatus(transactionId, CashStatusConfig.Finished);
            if(result)
                return Json("提交成功", JsonRequestBehavior.AllowGet);
            return Json("提交失败", JsonRequestBehavior.AllowGet);
        }
    }
}