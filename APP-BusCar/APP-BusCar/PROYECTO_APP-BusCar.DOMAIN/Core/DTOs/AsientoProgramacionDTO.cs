using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.DTOs
{
    public class AsientoProgramacionDTO
    {
        public int IdAsientoProg { get; set; }
        public int? IdProgramacion { get; set; }
        public int? IdAsiento { get; set; }
        public decimal CostoAsiento { get; set; }
        public string? Estado { get; set; }
        
    }

    public class AsientoProgramacionCreateDTO
    {
        public int? IdProgramacion { get; set; }
        public int? IdAsiento { get; set; }
        public decimal CostoAsiento { get; set; }
        public string? Estado { get; set; }
    }

    public class AsientoProgramacionAsientoDTO
    {
        public int? IdProgramacion { get; set; }
        public decimal CostoAsiento { get; set; }

        public AsientoDTO IdAsientoNavigation { get; set; }

    }

}
