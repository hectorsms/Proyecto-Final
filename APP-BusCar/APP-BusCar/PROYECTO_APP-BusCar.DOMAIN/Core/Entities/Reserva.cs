using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Reserva
    {
        public Reserva()
        {
            DetalleReserva = new HashSet<DetalleReserva>();
        }

        public int IdReserva { get; set; }
        public int? IdCliente { get; set; }
        public string? NroReserva { get; set; }
        public DateTime? FechaReserva { get; set; }
        public TimeSpan? HoraReserva { get; set; }
        public string? Estado { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual ICollection<DetalleReserva> DetalleReserva { get; set; }
    }
}
