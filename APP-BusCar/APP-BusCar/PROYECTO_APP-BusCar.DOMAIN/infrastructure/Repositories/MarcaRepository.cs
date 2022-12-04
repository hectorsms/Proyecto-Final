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
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DB_BUSContext _context;

        public MarcaRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marca>> GetMarcas()
        {
            var marcas = await _context.Marca.ToListAsync();
            return marcas;
        }
        public async Task<Marca> GetMarca(int id)
        {
            return await _context.Marca.Where(x => x.IdMarca == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Marca marca)
        {
            await _context.Marca.AddAsync(marca);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Marca marca)
        {
            _context.Marca.Update(marca);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            if (marca == null)
                return false;

            _context.Marca.Remove(marca);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}