using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Origen
    {
        public Origen()
        {
            Precio = new HashSet<Precio>();
            Programacion = new HashSet<Programacion>();
        }

        public int IdOrigen { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Precio> Precio { get; set; }
        public virtual ICollection<Programacion> Programacion { get; set; }
    }
}
