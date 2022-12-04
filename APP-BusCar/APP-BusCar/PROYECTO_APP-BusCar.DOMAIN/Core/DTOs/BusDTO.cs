using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.DTOs
{
    public class BusDTO
    {
        public int IdBus { get; set; }
        public int? IdModelo { get; set; }
        public int? IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public string? Placa { get; set; }
        public int? NroAsientos { get; set; }
        public string? Estado { get; set; }
    }

    public class BusCreateDTO
    {
        public int? IdModelo { get; set; }
        public int? IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public string? Placa { get; set; }
        public int? NroAsientos { get; set; }
        public string? Estado { get; set; }
    }
}