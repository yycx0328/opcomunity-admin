using BackStage.Core;
using BackStage.Core.Log;
using BackStage.Service.Abstracts;
using BackStage.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace BackStage.Web.Areas.Business.Controllers
{
    public class BaseController : Controller
    {
        public IPageViewService pageViewService { get; set; }
        /// <summary>
        /// 当前登录用户
        /// </summary>
        protected UserDto CurrentUser { get; private set; }
        /// <summary>
        /// 是否登录
        /// </summary>
        protected bool IsLogined { get; set; }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // TODO
            //用户信息处理
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity as FormsIdentity;
                CurrentUser = new UserDto
                {
                    Id = Convert.ToInt32(user.Ticket.UserData),
                    LoginName = User.Identity.Name
                };
            }

            IsLogined = CurrentUser != null && CurrentUser.Id > 0;

            ViewRecord(requestContext);
        }

        /// <summary>
        /// 访问记录
        /// </summary>
        /// <param name="_context"></param>
        void ViewRecord(RequestContext _context)
        {
            try
            {
                var dto = new PageViewDto
                {
                    UserId = IsLogined ? CurrentUser.Id : 0,
                    LoginName = IsLogined ? CurrentUser.LoginName : string.Empty,
                    Url = _context.HttpContext.Request.Url.PathAndQuery.ToLower(),
                    IP = WebHelper.GetClientIP()
                };
                pageViewService.Add(dto);
            }
            catch (Exception ex)
            {
                Logger.Log("访问记录", ex);
            }
        }
    }
}