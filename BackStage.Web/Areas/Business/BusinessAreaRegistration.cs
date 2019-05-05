using System.Web.Mvc;

namespace BackStage.Web.Areas.Business
{
    public class BusinessAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Business";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Business-Default",
                url: "Business/{controller}/{action}/{moudleId}/{menuId}/{btnId}/{id}",
                defaults:
                    new
                    {
                        controller = "Control",
                        action = "Index",
                        moudleId = UrlParameter.Optional,
                        menuId = UrlParameter.Optional,
                        btnId = UrlParameter.Optional,
                        id = UrlParameter.Optional
                    }
                );

            context.MapRoute(
                name: "Business-Default-Menu",
                url: "Business/{controller}/{action}/{moudleId}/{menuId}/{btnId}",
                defaults:
                    new
                    {
                        controller = "Control",
                        action = "Index",
                        moudleId = UrlParameter.Optional,
                        menuId = UrlParameter.Optional,
                        btnId = UrlParameter.Optional
                    }
                );

            context.MapRoute(
                "Business_default",
                "Business/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}