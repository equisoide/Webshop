using System.Web.Mvc;

namespace Webshop.Web.Controllers
{
    /// <summary>
    /// Controller to manage the Homepage.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Displays the Homepage.
        /// </summary>
        /// <example>GET: /</example>
        /// <returns>View with the Homepage.</returns>
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Products");
        }

        // <summary>
        /// Displays the About page.
        /// </summary>
        /// <example>GET: About</example>
        /// <returns>View with the About page.</returns>
        public ActionResult About()
        {
            return View();
        }
    }
}