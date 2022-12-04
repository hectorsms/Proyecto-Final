using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class OutProgramacionViaje
    {
        [Key]
        public Int64 RankNro { get; set; }
        public int IdProgramacion { get; set; }
        public TimeSpan? Hora { get; set; }
        
        public int? IdNivel { get; set; }
        public String? NombreNivel { get; set; }
        public int? NroAsientoLibre { get; set; }
        public decimal? CostoMinimo { get; set; }
        public decimal? CostoMaximo { get; set; }


    }
}
