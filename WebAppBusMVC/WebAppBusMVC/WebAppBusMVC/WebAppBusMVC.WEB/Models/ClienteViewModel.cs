namespace WebAppBusMVC.WEB.Models
{
    public class ClienteViewModel
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
    }
    public class ClienteCreateViewModel
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




public class ClienteInsertViewModel
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

}


