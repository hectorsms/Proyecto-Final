using Microsoft.AspNetCore.Mvc;

namespace WebAppBusMVC.WEB.Areas.Reporteria.Controllers
{
    [Area("Reporteria")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
