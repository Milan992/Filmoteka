using System.Web.Mvc;

namespace Filmoteka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movies()
        {
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Genres()
        {
            return RedirectToAction("Index", "Genres");

        }

        public ActionResult Actors()
        {
            return RedirectToAction("Index", "Actors");
        }

        public ActionResult Directors()
        {
            return RedirectToAction("Index", "Directors");

        }
    }
}