using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Comprobante
    {
        public int IdComprobante { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }
}
