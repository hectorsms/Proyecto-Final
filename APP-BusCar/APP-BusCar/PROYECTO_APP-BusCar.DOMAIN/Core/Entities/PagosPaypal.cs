using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class PagosPaypal
    {
        public int IdPago { get; set; }
        public DateTime? FechaPago { get; set; }
        public string? Dni { get; set; }
        public string? Nombres { get; set; }
        public string? Correo { get; set; }
        public string? DocumentoReferencia { get; set; }
        public string? TxnId { get; set; }
        public string? Moneda { get; set; }
        public int? NumeroItems { get; set; }
        public decimal? Importe { get; set; }
        public string? Estado { get; set; }
    }
}
