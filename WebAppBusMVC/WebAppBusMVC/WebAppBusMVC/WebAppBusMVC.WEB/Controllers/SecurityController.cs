using Microsoft.AspNetCore.Mvc;
using WebAppBusMVC.WEB.Models;
using WebAppBusMVC.WEB.Services;

namespace WebAppBusMVC.WEB.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Validate(string usuario1, string clave)
        {

            var userAuth = new UsersAuthenticationViewModel()
            {
                Usuario1 = usuario1,
                Clave = clave
            };

            var userResponse = await UsuarioService.Login(userAuth);

            if (userResponse.IdUser == 0)
                return RedirectToAction("Login", "Security");

            var roleCode =userResponse.Personal.IdCargo;
            if (roleCode == 1)
                return RedirectToAction("Index", "Home", new { Area = "Administracion" });
            else if (roleCode == 4)
                return RedirectToAction("Index", "Home", new { Area = "Ventas" });
            else
                return RedirectToAction("Login", "Security");
  
        }

    }
}
