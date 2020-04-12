using System.Web.Mvc;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Car()
        {
            ViewBag.Message = "Car Master";

            return View();
        }

        public ActionResult Calculator()
        {
            ViewBag.Message = "Calculator";

            return View();
        }
    }
}
