using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.DTOs
{
    public class OrigenDTO
    {
        public int IdOrigen { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
    }

    public class OrigenCreateDTO
    {
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
    }
}
