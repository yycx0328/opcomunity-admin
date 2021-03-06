﻿using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using BackStage.Core.Extentions;
using BackStage.Service.Dto;
using BackStage.ServiceBasis.Dto;

namespace BackStage.Web.Areas.Adm.Controllers
{
    /// <summary>
    /// Page view
    /// </summary>
    public class PageViewController : AdmBaseController
    {

        #region Page

        // GET: Adm/PageView
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            return View();
        }

        #endregion

        #region Ajax

        public JsonResult GetList(int moudleId, int menuId, int btnId)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<PageViewDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.LoginName.Contains(queryBase.SearchKey));

            var dto = pageViewService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}