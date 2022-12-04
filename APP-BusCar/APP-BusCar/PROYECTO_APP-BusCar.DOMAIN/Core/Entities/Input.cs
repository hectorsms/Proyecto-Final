using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Entities
{
    public class Input
    {
        [Key]
        public int Id { get; set; }
        public string? Fecha { get; set; }

    }
}
