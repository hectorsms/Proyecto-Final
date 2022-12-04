using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class AsientoProgramacion
    {
        public AsientoProgramacion()
        {
            DetalleReserva = new HashSet<DetalleReserva>();
        }

        public int IdAsientoProg { get; set; }
        public int? IdProgramacion { get; set; }
        public int? IdAsiento { get; set; }
        public string? Estado { get; set; }
        public decimal CostoAsiento { get; set; }

        public virtual Programacion? IdProgramacionNavigation { get; set; }
        public virtual ICollection<DetalleReserva> DetalleReserva { get; set; }
        public virtual Asiento? IdAsientoNavigation { get; set; }
    }
}
