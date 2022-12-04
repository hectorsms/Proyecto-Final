using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PROYECTO_APP_BusCar.DOMAIN.Core.Entities;
using PROYECTO_APP_BusCar.DOMAIN.Core.Interfaces;
using PROYECTO_APP_BusCar.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_APP_BusCar.DOMAIN.infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DB_BUSContext _context;
        public UsuarioRepository(DB_BUSContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var usuarios = await _context.Usuario.ToListAsync();
            return usuarios;
        }
        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuario.Where(x => x.IdUser == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> GetUsuarioWithPersonal(int id)
        {
            var usuario = await _context.Usuario.Include(x => x.Personal)
                                                  .Where(x => x.IdUser == id).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<bool> Insert(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
                return false;

            _context.Usuario.Remove(usuario);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<Usuario> Login(string usuario1, string clave)
        {
            var user = await _context.Usuario.Include(x => x.Personal)
                .Where(x => x.Usuario1 == usuario1 && x.Clave == clave && x.Estado=="1")
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<IEnumerable<Output>> GetOutputDateName(Input input)
        {
            string StoredProc = "exec sp_FechaNombre " +
                    "@fecha = '" + input.Fecha + "'";

            var nombreFecha = await _context.Output.FromSqlRaw(StoredProc).ToListAsync();

            return nombreFecha;
        }

    }
}