using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public class OutProgramacionAsiento
    {
        [Key]
        public int? IdAsientoProgP { get; set; }
        public decimal? CostoAsientoP { get; set; }
        public int? IdAsientoP { get; set; }
        public int? NumeroAsientoP { get; set; }
        public int? IdAsientoProgV { get; set; }
        public decimal? CostoAsientoV { get; set; }
        public int? IdAsientoV { get; set; }
        public int? NumeroAsientoV { get; set; }
        public int? IdNivel { get; set; }

    }
}
