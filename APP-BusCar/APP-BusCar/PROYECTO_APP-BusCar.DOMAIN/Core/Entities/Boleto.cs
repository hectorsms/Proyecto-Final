using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Boleto
    {
        public int? IdBoleto { get; set; }
        public int? IdCliente { get; set; }
        public int? IdAsientoProg { get; set; }
        public int? IdUser { get; set; }
        public int? IdDestino { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaViaje { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public TimeSpan? HoraPartida { get; set; }
        public int? IdComprobante { get; set; }
        public string? Serie { get; set; }
        public string? Correlativo { get; set; }
        public string? Moneda { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Importe { get; set; }
        public string? DocumentoReferencia { get; set; }
        public string? Estado { get; set; }

        public virtual AsientoProgramacion? IdAsientoProgNavigation { get; set; }
        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Comprobante? IdComprobanteNavigation { get; set; }
        public virtual Destino? IdDestinoNavigation { get; set; }
        public virtual Usuario? IdUserNavigation { get; set; }
    }
}
