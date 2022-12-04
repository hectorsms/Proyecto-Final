namespace WebAppBusMVC.WEB.Models
{
    public class PasajeroViewModel
    {
        public int TipDoc { get; set; }
        public string? NumDoc { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Sexo { get; set; }
        public string? FecNac { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? RUC { get; set; }
        public string? RazonSocial { get; set; }
        public string? DireccionEmpresa { get; set; }
        public string? Direccion { get; set; }
        public int NumeroAsiento { get; set; }
        public decimal CostoAsiento { get; set; }
    }
}
