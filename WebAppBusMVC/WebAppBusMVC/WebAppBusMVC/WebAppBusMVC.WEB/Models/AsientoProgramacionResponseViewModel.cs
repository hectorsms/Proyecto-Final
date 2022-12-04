namespace WebAppBusMVC.WEB.Models
{
	public class AsientoProgramacionResponseViewModel
	{
        public int? IdProgramacion { get; set; }
        public decimal CostoAsiento { get; set; }

        public AsientoViewModel IdAsientoNavigation { get; set; }
    }
}
