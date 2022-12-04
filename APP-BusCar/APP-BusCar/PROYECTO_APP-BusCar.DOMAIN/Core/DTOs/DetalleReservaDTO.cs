using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.DTOs
{
    public class DetalleReservaDTO
    {
        public int IdDetalleReserva { get; set; }
        public int? IdReserva { get; set; }
        public int? IdAsientoProg { get; set; }
        public string? NroDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Estado { get; set; }
    }

    public class DetalleReservaCreateDTO
    {
        public int? IdReserva { get; set; }
        public int? IdAsientoProg { get; set; }
        public string? NroDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Estado { get; set; }
    }

}