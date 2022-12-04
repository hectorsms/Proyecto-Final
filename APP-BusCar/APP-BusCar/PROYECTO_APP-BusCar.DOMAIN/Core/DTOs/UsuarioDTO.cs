using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.DTOs
{
    public class UsuarioDTO
    {
        public int IdUser { get; set; }
        public string? Usuario1 { get; set; }
        public string? Clave { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Estado { get; set; }
        public int? IdPersonal { get; set; }
    }

    public class UsuarioCreateDTO
    {       
        public string? Usuario1 { get; set; }
        public string? Clave { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Estado { get; set; }
        public int? IdPersonal { get; set; }
    }

    public class UsuarioPersonalDTO
    {
        public int IdUser { get; set; }
        public string? Usuario1 { get; set; }
        public string? Clave { get; set; }
        public string? Estado { get; set; }

        public virtual PersonalDTO Personal { get; set; }
    }

    public class UsersLoginResponseDTO
    {

        public int IdUser { get; set; }
        public string? Usuario1 { get; set; }       
        public string? Estado { get; set; }

        public virtual PersonalDTO Personal { get; set; }

    }

    public class UsersAuthenticationDTO
    {
        public string Usuario1 { get; set; }
        public string Clave { get; set; }
    }

}
