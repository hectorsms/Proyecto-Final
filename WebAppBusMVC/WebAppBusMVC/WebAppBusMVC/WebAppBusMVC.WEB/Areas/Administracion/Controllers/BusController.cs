using Microsoft.AspNetCore.Mvc;
using WebAppBusMVC.WEB.Models;
using WebAppBusMVC.WEB.Services;

namespace WebAppBusMVC.WEB.Areas.Administracion.Controllers
{
    public class BusController : Controller
    {
        public IActionResult IndexB()
        {
            return View();
        }
        public async Task<IActionResult> ListadoB()
        {
            var bus = await BusService.Getbus();
            ViewBag.ListadoBus = bus;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Grabar(int idBus, int idMarca
            , string descripcion, string placa, int NroAsientos
            , string estado)
        {
            var bus = new BusInsertViewModel()
            {
                IdBus = idBus,
                IdMarca = idMarca,
                Descripcion = descripcion,
                Placa = placa,
                NroAsientos = NroAsientos,
                Estado = estado
              
            };
            bool exito = true;
            exito = await BusService.InsertBus(bus);
            return Json(exito);
        }

       

    }
}






