using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using WebAppBusMVC.WEB.Extensions;
using WebAppBusMVC.WEB.Models;
using WebAppBusMVC.WEB.Services;

namespace WebAppBusMVC.WEB.Areas.Ventas.Controllers
{
    [Area("Ventas")]
    public class VentaBoletoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult VentaBoleto()
        //{

        //    return View();
        //}
        [HttpPost]
        public IActionResult AñadirPasajeros(InAddPasajerosViewModel inAddPasajerosViewModel)
        {

            List<PasajeroViewModel> pasajeros = new List<PasajeroViewModel>();

            for (var i = 1; i <= 10; i ++ ) {

                PasajeroViewModel pasajero = new PasajeroViewModel()
                {
                    TipDoc = 1,
                    NumDoc = "",
                    Nombres = "",
                    ApellidoPaterno = "",
                    ApellidoMaterno = "",
                    Sexo = "",
                    FecNac = "",
                    Telefono = "",
                    Correo = "",
                    RUC = "",
                    RazonSocial = "",
                    DireccionEmpresa = "",
                    NumeroAsiento = 0,
                    CostoAsiento = 0
                };
                pasajeros.Add(pasajero);
            }

            int propertyCount =0;
            foreach (System.Reflection.PropertyInfo propInfo in inAddPasajerosViewModel.GetType().GetProperties()  )
            {

                var CampoName = propInfo.Name;

                var indice = CampoName.Substring(CampoName.IndexOf("_") + 1);
                var CampoValor = Convert.ToString( propInfo.GetValue(inAddPasajerosViewModel));
                

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "NumeroAsiento")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].NumeroAsiento = Convert.ToInt32( propInfo.GetValue(inAddPasajerosViewModel));
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "CostoAsiento")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].CostoAsiento = Convert.ToDecimal(propInfo.GetValue(inAddPasajerosViewModel));
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_") ) == "TipDoc") 
                {
                    pasajeros[Convert.ToInt32(indice) - 1].TipDoc = Convert.ToInt32(propInfo.GetValue(inAddPasajerosViewModel));
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "NumDoc")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].NumDoc = CampoValor;
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "Nombres")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].Nombres = CampoValor;
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "ApellidoPaterno")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].ApellidoPaterno = CampoValor;
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "ApellidoMaterno")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].ApellidoMaterno = CampoValor;
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "Sexo")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].Sexo = CampoValor;
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "FecNac")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].FecNac = CampoValor;
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "Telefono")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].Telefono = CampoValor;
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "Correo")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].Correo = CampoValor;
                }

                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "RUC")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].RUC = CampoValor;
                }
                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "RazonSocial")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].RazonSocial = CampoValor;
                }
                if (CampoName.Substring(0, CampoName.IndexOf("_")) == "DireccionEmpresa")
                {
                    pasajeros[Convert.ToInt32(indice) - 1].DireccionEmpresa = CampoValor;
                }

                    propertyCount++;
            }
            HttpContext.Session.SetObject("SESSIONPASAJEROS", pasajeros);
            return RedirectToAction("VentaBoletoPago", "VentaBoleto", new { Area = "Ventas" });
        }

        [HttpPost]
        public IActionResult AñadirAsientos(InAddAsientosViewModel inAddAsientosViewModel)
        {            
            List<AsientoViewModel> asientos = new List<AsientoViewModel>();

            int propertyCount = 0, asientoCount=1 ;


            Type t = inAddAsientosViewModel.GetType();
            PropertyInfo[] props = t.GetProperties();
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                object value = prp.GetValue(inAddAsientosViewModel, new object[] { });
                dict.Add(prp.Name, value);
            }

            decimal CostoAsiento = 0;
            foreach (System.Reflection.PropertyInfo propInfo in inAddAsientosViewModel.GetType().GetProperties())
            {
                
                var CampoValue = propInfo.GetValue(inAddAsientosViewModel);
                var CampoName = propInfo.Name;
                if(CampoName.Contains("check_") )
                { 
                    if (CampoValue != null)
                    {
                        AsientoViewModel asiento = new AsientoViewModel()
                        {
                            IdAsiento = asientoCount,
                            NumeroAsiento =  Convert.ToInt32( CampoName.Substring(6)),
                            CostoAsiento = Convert.ToDecimal (dict["CostoAsiento_"+ CampoName.Substring(6)])                        
                    };
                        asientos.Add(asiento);
                        asientoCount++;
                    }
                }
                propertyCount++;
            }
            HttpContext.Session.SetObject("SESSIONASIENTOS", asientos);

            List<PasajeroViewModel> pasajeros = new List<PasajeroViewModel>();

            for (var i = 1; i <= 10; i++)
            {

                PasajeroViewModel pasajero = new PasajeroViewModel()
                {
                    TipDoc = 1,
                    NumDoc = "",
                    Nombres = "",
                    ApellidoPaterno = "",
                    ApellidoMaterno = "",
                    Sexo = "",
                    FecNac = "",
                    Telefono = "",
                    Correo = "",
                    RUC = "",
                    RazonSocial = "",
                    DireccionEmpresa = "",
                    NumeroAsiento = 0
                };
                pasajeros.Add(pasajero);
            }

            HttpContext.Session.SetObject("SESSIONPASAJEROS", pasajeros);


            return RedirectToAction("VentaBoletoDatosPersonales", "VentaBoleto", new { Area = "Ventas" });
        }

        [HttpPost]
        public IActionResult AñadirProgramacion(InAddProgramacionViewModel inAddProgramacion)
        {
            Viaje viaje;
            viaje = HttpContext.Session.GetObject<Viaje>("SESSIONVIAJE");

            viaje.IdProgramacionIda = inAddProgramacion.IdProgramacionIda;
            viaje.IdProgramacionRetorno = inAddProgramacion.IdProgramacionRetorno;
            viaje.horaIda = inAddProgramacion.horaIda;
            viaje.horaRetorno = inAddProgramacion.horaRetorno;
            HttpContext.Session.SetObject("SESSIONVIAJE", viaje);

            List<AsientoViewModel> asientos = new List<AsientoViewModel>();
            HttpContext.Session.SetObject("SESSIONASIENTOS", asientos);

            return RedirectToAction("VentaBoletoAsiento", "VentaBoleto", new { Area = "Ventas" });
        }

        [HttpPost]
        public async Task<IActionResult> AñadirViaje(int idViajeIda,int idViajeRetorno, DateTime fechaIda, DateTime fechaRetorno )
        {
            Viaje viaje;
            // bool exito = true;
            if (HttpContext.Session.GetString("SESSIONVIAJE") == null)
            {                
                viaje = new Viaje();
            }
            else
            {
                viaje = HttpContext.Session.GetObject<Viaje>("SESSIONVIAJE");                
            }
            viaje.IdViajeIda = idViajeIda;
            viaje.IdViajeRetorno = idViajeRetorno;
            viaje.FechaIda = Convert.ToDateTime(fechaIda).ToString("yyyy-MM-dd"); 
            viaje.FechaRetorno = Convert.ToDateTime(fechaRetorno).ToString("yyyy-MM-dd");                        

            var inputDateNameIda = new InputDateViewModel()
            {
                Id = 1,
                Fecha = viaje.FechaIda
            };

            var inputDateNameRetorno = new InputDateViewModel()
            {
                Id = 1,
                Fecha = viaje.FechaRetorno
            };

            var nombreViajeIda = await VentaBoletoService.GetOrigenById(viaje.IdViajeIda);
            viaje.NombreViajeIda = nombreViajeIda.Ciudad;
            var nombreViajeRetorno = await VentaBoletoService.GetDestinoById(viaje.IdViajeRetorno);
            viaje.NombreViajeRetorno = nombreViajeRetorno.Ciudad;

            var outPutDateIda = await VentaBoletoService.GetDateName(inputDateNameIda);
            var outPutDateRetorno = await VentaBoletoService.GetDateName(inputDateNameRetorno);

            foreach (var item in outPutDateIda)
            {
                viaje.FechaNombreIda = item.Semana + " " +  item.Dia +" " +item.Mes + " de "+ item .Anho ;
            }

            foreach (var item in outPutDateRetorno)
            {
                viaje.FechaNombreRetorno = item.Semana + " " + item.Dia + " " + item.Mes + " de " + item.Anho;
            }



            HttpContext.Session.SetObject("SESSIONVIAJE", viaje);
            return RedirectToAction("VentaBoletoProgramacion","VentaBoleto",new { Area = "Ventas" });
            //return Json(exito);


        }
        public async Task<IActionResult> VentaBoleto()
        {
            
            var destinos = await VentaBoletoService.GetDestinos();
            var origenes = await VentaBoletoService.GetOrigenes();            
            ViewBag.ListaDestinos = destinos;
            ViewBag.ListaOrigenes = origenes;
            return View();

        }

        public IActionResult VentaBoletoProgramacion()
        {

            return View();
        }

        public async Task<IActionResult> VentaBoletoProgramacionList()
        {
            var viajeSession = HttpContext.Session.GetObject<Viaje>("SESSIONVIAJE");
            
            var inProgramacionViaje = new InProgramacionViajeViewModel()
            {
                IdOrigen = viajeSession.IdViajeIda,
                IdDestino = viajeSession.IdViajeRetorno ,
                Fecha = viajeSession.FechaIda
            };

            var programacionViaje = await VentaBoletoService.GetProgramacionViaje(inProgramacionViaje);
          
            ViewBag.ListaProgramacionViaje = programacionViaje;

            return PartialView();
        }

        public async Task<IActionResult> VentaBoletoProgramacionListRetorno()
        {
            var viajeSession = HttpContext.Session.GetObject<Viaje>("SESSIONVIAJE");

            var inProgramacionViaje = new InProgramacionViajeViewModel()
            {
                IdOrigen = viajeSession.IdViajeRetorno,
                IdDestino = viajeSession.IdViajeIda,
                Fecha = viajeSession.FechaRetorno
            };

            var programacionViaje = await VentaBoletoService.GetProgramacionViaje(inProgramacionViaje);

            ViewBag.ListaProgramacionViaje = programacionViaje;

            return PartialView();
        }

        public IActionResult VentaBoletoAsiento()
        {


            return View();
        }

        public async Task<IActionResult> VentaBoletoAsientoList()
        {

            Viaje viaje;
            viaje = HttpContext.Session.GetObject<Viaje>("SESSIONVIAJE");

            var asientos = HttpContext.Session.GetObject<List<AsientoViewModel>>("SESSIONASIENTOS");
            ViewBag.ListaAsientos = asientos;

            var listAsientoProgramacion = await VentaBoletoService.GetProgramacionAsiento(viaje.IdProgramacionIda);
            ViewBag.ListaAsientoProgramacion = listAsientoProgramacion;


            return PartialView();
        }
        public async Task<IActionResult> VentaBoletoDatosPersonales()
        {

            var asientos = HttpContext.Session.GetObject<List<AsientoViewModel>>("SESSIONASIENTOS");
            ViewBag.ListaAsientos = asientos;

            var pasajeros = HttpContext.Session.GetObject<List<PasajeroViewModel>>("SESSIONPASAJEROS");
            ViewBag.ListaPasajeros = pasajeros;

            var documentos = await VentaBoletoService.GetDocumentos();
            ViewBag.ListaDocumentos = documentos;

            return View();
        }

        public IActionResult VentaBoletoPago()
        {

            var pasajeros = HttpContext.Session.GetObject<List<PasajeroViewModel>>("SESSIONPASAJEROS");
            ViewBag.ListaPasajeros = pasajeros;
            return View();
        }


    }
    }
