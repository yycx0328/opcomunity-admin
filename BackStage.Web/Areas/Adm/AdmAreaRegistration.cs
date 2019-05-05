using System.Web.Mvc;

namespace BackStage.Web.Areas.Adm
{
    public class AdmAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Adm";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Admin-Default",
                url: "Adm/{controller}/{action}/{moudleId}/{menuId}/{btnId}/{id}",
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
                name: "Admin-Default-Menu",
                url: "Adm/{controller}/{action}/{moudleId}/{menuId}/{btnId}",
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
                "Adm_default",
                "Adm/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}