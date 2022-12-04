using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public partial class Output
    {
        [Key]
        public string? Dia { get; set; }
        public string? Semana { get; set; }
        public string? Mes { get; set; }
        public string? Anho { get; set; }

    }
}
