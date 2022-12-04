using Microsoft.AspNetCore.Mvc;

namespace WebAppBusMVC.WEB.Areas.Ventas.Controllers
{
    [Area("Ventas")]
    public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
