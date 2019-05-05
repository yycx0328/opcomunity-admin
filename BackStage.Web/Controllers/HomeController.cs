using System.Web.Mvc;

namespace BackStage.Web.Controllers
{
    /// <summary>
    /// home page
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Response.Redirect("Login/User");
            //return View();
            //return RedirectToAction("Login", "User", new { area = "Adm", a = 2, b = "b" });
            return RedirectToAction("Login", "User", new { area = "Adm" });
        }
    }
}