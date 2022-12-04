namespace WebAppBusMVC.WEB.Models
{
    public class BusViewModel
    {
        public int IdBus { get; set; }
        public int? IdModelo { get; set; }
        public int? IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public string? Placa { get; set; }
        public int? NroAsientos { get; set; }
        public string? Estado { get; set; }
    }
    public class BusCreateViewModel
    {
        public int IdBus { get; set; }
        public int? IdModelo { get; set; }
        public int? IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public string? Placa { get; set; }
        public int? NroAsientos { get; set; }
        public string? Estado { get; set; }
    }




public class BusInsertViewModel
{
        public int IdBus { get; set; }
        public int? IdModelo { get; set; }
        public int? IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public string? Placa { get; set; }
        public int? NroAsientos { get; set; }
        public string? Estado { get; set; }
    }

}


