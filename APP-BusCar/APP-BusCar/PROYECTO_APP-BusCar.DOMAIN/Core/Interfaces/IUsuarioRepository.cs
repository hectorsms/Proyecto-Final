using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;

namespace PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> Delete(int id);
        Task<Usuario> GetUsuario(int id);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuarioWithPersonal(int id);
        Task<bool> Insert(Usuario usuario);
        Task<bool> Update(Usuario usuario);

        Task<Usuario> Login(string usuario1, string clave);
        Task<IEnumerable<Output>> GetOutputDateName(Input input);
    }
}