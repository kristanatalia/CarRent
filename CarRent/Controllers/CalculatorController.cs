using System.Web.Mvc;

namespace CarRent.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Calculator";

            return View();
        }
    }
}
