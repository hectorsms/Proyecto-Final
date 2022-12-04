using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.DTOs
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public int? IdDocumento { get; set; }
        public string? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
        public string? Sexo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Estado { get; set; }
        public string? Correo { get; set; }
        public string? ApellidoM { get; set; }
    }

    public class ClienteCreateDTO
    {
        public int? IdDocumento { get; set; }
        public string? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
        public string? Sexo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Estado { get; set; }
        public string? Correo { get; set; }
        public string? ApellidoM { get; set; }

    }
}