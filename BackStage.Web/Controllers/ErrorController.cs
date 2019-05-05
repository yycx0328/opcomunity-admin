using System.Web.Mvc;

namespace BackStage.Web.Controllers
{
    /// <summary>
    /// error
    /// </summary>
    public class ErrorController : Controller
    {
        // GET: NotFound
        public ActionResult NotFound()
        {
            return View();
        }
    }
}