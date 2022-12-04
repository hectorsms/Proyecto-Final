namespace WebAppBusMVC.WEB.Models
{
	public class InAddProgramacionViewModel
	{
        public int IdProgramacionIda { get; set; }
        public TimeSpan? horaIda { get; set; }
        public int IdProgramacionRetorno { get; set; }
        public TimeSpan? horaRetorno { get; set; }        
    }
}
