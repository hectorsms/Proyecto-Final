using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppBusMVC.WEB.Models
{
    [Table("Viaje")]
    public class Viaje
    {
        public int IdViajeIda { get; set; }    
        public int IdViajeRetorno { get; set; }

        public String? NombreViajeIda { get; set; }
        public String? NombreViajeRetorno { get; set; }

        public String? FechaIda { get; set; }
        public String? FechaRetorno { get; set; }

        public String? FechaNombreIda { get; set; }
        public String? FechaNombreRetorno { get; set; }

        public int IdProgramacionIda { get; set; }
        public TimeSpan? horaIda { get; set; }
        public int IdProgramacionRetorno { get; set; }
        public TimeSpan? horaRetorno { get; set; }

    }
}
