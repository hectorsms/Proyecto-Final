namespace WebAppBusMVC.WEB.Models
{
    public class PersonalLoginResponseViewModel
    {
        public int IdPersonal { get; set; }
        public string? Dni { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public int? IdCargo { get; set; }
    }
}
