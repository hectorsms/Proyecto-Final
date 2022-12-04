using System;
using System.Collections.Generic;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Tripulacion
    {
        public int IdTripulacion { get; set; }
        public int? IdPersonal { get; set; }
        public int? IdProgramacion { get; set; }

        public virtual Personal? IdPersonalNavigation { get; set; }
        public virtual Programacion? IdProgramacionNavigation { get; set; }
    }
}
