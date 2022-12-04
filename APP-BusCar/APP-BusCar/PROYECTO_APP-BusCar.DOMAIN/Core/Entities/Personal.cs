using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Personal
    {
        public Personal()
        {
            Tripulacion = new HashSet<Tripulacion>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdPersonal { get; set; }
        public string? Dni { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Estado { get; set; }
        public int? IdCargo { get; set; }

        public virtual Cargo? IdCargoNavigation { get; set; }
        public virtual ICollection<Tripulacion> Tripulacion { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
