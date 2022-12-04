using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Asiento
    {
        public int? IdAsiento { get; set; }
        public int? IdBus { get; set; }
        public int? IdNivel { get; set; }
        public int? NumeroAsiento { get; set; }
        public decimal CostoAsiento { get; set; }
        public string? Estado { get; set; }

        public virtual Bus? IdBusNavigation { get; set; }
        public virtual Nivel? IdNivelNavigation { get; set; }
    }
}
