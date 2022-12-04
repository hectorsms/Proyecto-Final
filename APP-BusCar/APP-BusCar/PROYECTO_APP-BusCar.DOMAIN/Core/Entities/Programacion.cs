using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Programacion
    {
        public Programacion()
        {
            AsientoProgramacion = new HashSet<AsientoProgramacion>();
            Tripulacion = new HashSet<Tripulacion>();
        }

        public int IdProgramacion { get; set; }
        public int? IdOrigen { get; set; }
        public int? IdDestino { get; set; }
        public int? IdBus { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public decimal? Costo { get; set; }
        public string? Estado { get; set; }

        public virtual Bus? IdBusNavigation { get; set; }
        public virtual Destino? IdDestinoNavigation { get; set; }
        public virtual Origen? IdOrigenNavigation { get; set; }
        public virtual ICollection<AsientoProgramacion> AsientoProgramacion { get; set; }
        public virtual ICollection<Tripulacion> Tripulacion { get; set; }
    }
}
