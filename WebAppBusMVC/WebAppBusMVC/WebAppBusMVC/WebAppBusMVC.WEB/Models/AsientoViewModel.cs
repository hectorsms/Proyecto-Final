namespace WebAppBusMVC.WEB.Models
{
	public class AsientoViewModel
	{
        public int IdAsiento { get; set; }
        public int? IdBus { get; set; }
        public int? IdNivel { get; set; }
        public int? NumeroAsiento { get; set; }
        public decimal CostoAsiento { get; set; }
        public string? Estado { get; set; }
    }
}
