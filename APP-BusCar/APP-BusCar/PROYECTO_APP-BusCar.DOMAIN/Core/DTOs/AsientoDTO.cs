using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.DTOs
{
    public class AsientoDTO
    {
        public int? IdAsiento { get; set; }
        public int? IdBus { get; set; }
        public int? IdNivel { get; set; }
        public int? NumeroAsiento { get; set; }
        public decimal CostoAsiento { get; set; }
        public string? Estado { get; set; }

    }

    public class AsientoCreateDTO
    {
        public int? IdBus { get; set; }
        public int? IdNivel { get; set; }
        public int? NumeroAsiento { get; set; }
        public decimal CostoAsiento { get; set; }
        public string? Estado { get; set; }

    }
}
