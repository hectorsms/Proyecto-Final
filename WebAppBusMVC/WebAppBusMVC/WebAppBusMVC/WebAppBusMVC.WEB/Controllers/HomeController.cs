using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppBusMVC.WEB.Models;

namespace WebAppBusMVC.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    
        public IActionResult Registros()
        {
            return View();
        }

        public IActionResult Destinos()
        {
            return View();
        }

    
        public IActionResult Pasajes()
        {
            return View();
        }


        public IActionResult Reportes()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}