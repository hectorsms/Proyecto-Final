using Microsoft.AspNetCore.Mvc;
using WebAppBusMVC.WEB.Models;
using WebAppBusMVC.WEB.Services;

namespace WebAppBusMVC.WEB.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    public class MantenimientoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Listado()
        {
            var clientes = await ClienteService.GetCliente();
            ViewBag.ListadoCliente = clientes;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Grabar (int id_cliente,int id_documento
            , string dni, string nombre, string apellido, DateTime fecha_nacimiento
            , string ruc, string razon_social, string sexo, string telefono
            , string direccion, string estado, string correo, string apellidoM )
        {
            var cliente = new ClienteInsertViewModel()
            {
                IdDocumento = id_documento,
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                FechaNacimiento = fecha_nacimiento,
                Ruc = ruc,
                RazonSocial = razon_social,
                Sexo = sexo,
                Telefono = telefono,
                Direccion = direccion,
                Estado = estado,
                Correo = correo,
                ApellidoM = apellidoM
            };
            bool exito = true;
            exito = await ClienteService.InsertCliente(cliente);
            return Json(exito);
        }

    public async Task<IActionResult> Eliminar(int id)
        {
            bool exito = await ClienteService.DeleteCliente(id);
            return Json(exito);
        }

        public async Task<IActionResult> Obtener(int id)
        {
            var customer = await ClienteService.InsertClienteById(id);
            return Json(customer);
        }
    }
}
    





