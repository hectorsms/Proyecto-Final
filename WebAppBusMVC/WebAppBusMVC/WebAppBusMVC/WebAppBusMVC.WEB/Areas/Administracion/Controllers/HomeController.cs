using Microsoft.AspNetCore.Mvc;

namespace WebAppBusMVC.WEB.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
