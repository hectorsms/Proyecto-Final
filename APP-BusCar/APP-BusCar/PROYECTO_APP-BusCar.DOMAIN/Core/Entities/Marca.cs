using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Marca
    {
        public Marca()
        {
            Bus = new HashSet<Bus>();
        }

        public int IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Bus> Bus { get; set; }
    }
}
