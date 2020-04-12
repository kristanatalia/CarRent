using System.Web.Mvc;

namespace CarRent.Controllers
{
    public class CarController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Car Master";
            return View();
        }
    }
}
