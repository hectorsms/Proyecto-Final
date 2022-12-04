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
    public class ModeloRepository : IModeloRepository
    {
        private readonly DB_BUSContext _context;

        public ModeloRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Modelo>> GetModelos()
        {
            var modelos = await _context.Modelo.ToListAsync();
            return modelos;
        }
        public async Task<Modelo> GetModelo(int id)
        {
            return await _context.Modelo.Where(x => x.IdModelo == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Modelo modelo)
        {
            await _context.Modelo.AddAsync(modelo);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Modelo modelo)
        {
            _context.Modelo.Update(modelo);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo == null)
                return false;

            _context.Modelo.Remove(modelo);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}