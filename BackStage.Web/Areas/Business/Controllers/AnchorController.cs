using Infrastructure;
using Opcomunity.Service.Interface;
using Opcomunity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class AnchorController : BaseController
    { 
        // GET: Business/Anchor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Business/Anchor
        public JsonResult GetList(int pageIndex, int pageSize, string condition, string auth)
        {
            var service = Ioc.Get<IAnchorService>();
            var data = service.GetAnchorList(pageIndex, pageSize, condition, auth);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryRelation(long anchorId)
        {
            var service = Ioc.Get<IAnchorService>();
            var data = service.GetAnchorCategoryRelation(anchorId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public JsonResult InitEdit(string userId)
        {
            var iUserId = TypeHelper.TryParse(userId, 0L);
            if(iUserId<=0)
                return Json(null, JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IAnchorService>();
            var data = service.GetAnchor(iUserId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(long anchorId,string nickName, string description,int glamour, int cashRatio, int callRatio, bool isAuth,string categories)
        {
            if (anchorId<=0 || string.IsNullOrEmpty(nickName) || string.IsNullOrEmpty(description) 
                || glamour<0 ||cashRatio<=0 || callRatio<=0 || string.IsNullOrEmpty(categories))
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IAnchorService>();
            var result = service.EditAnchor(anchorId, nickName, description,glamour,cashRatio, callRatio,isAuth, categories);
            string message = "";
            if (result)
                message = "提交成功";
            else
                message = "主播信息错误";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetChatStatus(long anchorId)
        {
            if (anchorId <= 0)
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IAnchorService>();
            var result = service.SetChatStatus(anchorId,(int)NeteaseChatStatusConfig.OffLine);
            string message = "";
            if (result)
                message = "设置成功";
            else
                message = "主播信息错误";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetBlackAnchor(long anchorId)
        {
            if (anchorId <= 0)
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IAnchorService>();
            var result = service.SetBlackAnchor(anchorId);
            string message = "";
            if (result)
                message = "主播已拉黑";
            else
                message = "主播信息错误";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DelPhoto(long id)
        {
            if (id <= 0)
                return Json("参数错误", JsonRequestBehavior.AllowGet);
            var service = Ioc.Get<IAnchorService>();
            var result = service.DelPhoto(id);
            string message = "";
            if (result)
                message = "删除成功";
            else
                message = "删除失败";
            return Json(message, JsonRequestBehavior.AllowGet);
        }
    }
}