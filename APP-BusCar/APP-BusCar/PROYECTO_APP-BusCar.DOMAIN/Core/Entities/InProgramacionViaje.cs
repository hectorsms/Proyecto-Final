using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public class InProgramacionViaje
    {
        [Key]
        public int? IdOrigen { get; set; }
        public int? IdDestino { get; set; }
        public String? Fecha { get; set; }
    }
}
