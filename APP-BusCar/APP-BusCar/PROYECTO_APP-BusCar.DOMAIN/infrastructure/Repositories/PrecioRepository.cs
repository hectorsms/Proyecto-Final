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
    public class PrecioRepository : IPrecioRepository
    {
        private readonly DB_BUSContext _context;

        public PrecioRepository(DB_BUSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Precio>> GetPrecio()
        {
            var Precio = await _context.Precio.ToListAsync();
            return Precio;
        }
        public async Task<Precio> GetPrecio(int id)
        {
            return await _context.Precio.Where(x => x.IdPrecio == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Precio Precio)
        {
            await _context.Precio.AddAsync(Precio);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Precio Precio)
        {
            _context.Precio.Update(Precio);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var Precio = await _context.Precio.FindAsync(id);
            if (Precio == null)
                return false;

            _context.Precio.Remove(Precio);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}