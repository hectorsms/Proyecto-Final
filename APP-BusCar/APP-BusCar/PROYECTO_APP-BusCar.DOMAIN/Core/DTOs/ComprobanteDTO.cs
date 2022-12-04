using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.DTOs
{
    public class ComprobanteDTO
    {
        public int IdComprobante { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }

    public class ComprobanteCreateDTO
    {
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }
}