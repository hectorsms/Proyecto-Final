namespace WebAppBusMVC.WEB.Models
{
	public class OutProgramacionViajeViewModel
	{
        public Int64 RankNro { get; set; }
        public int IdProgramacion { get; set; }
        public TimeSpan? Hora { get; set; }
        public int? IdNivel { get; set; }
        public String? NombreNivel { get; set; }
        public int? NroAsientoLibre { get; set; }
        public decimal? CostoMinimo { get; set; }
        public decimal? CostoMaximo { get; set; }
    }
}
