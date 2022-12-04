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
    public class OrigenRepository : IOrigenRepository
    {
        private readonly DB_BUSContext _context;

        public OrigenRepository(DB_BUSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Origen>> GetOrigen()
        {
            var origen = await _context.Origen.ToListAsync();
            return origen;
        }
        public async Task<Origen> GetOrigen(int id)
        {
            return await _context.Origen.Where(x => x.IdOrigen == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Origen Origen)
        {
            await _context.Origen.AddAsync(Origen);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Origen Origen)
        {
            _context.Origen.Update(Origen);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var Origen = await _context.Origen.FindAsync(id);
            if (Origen == null)
                return false;

            _context.Origen.Remove(Origen);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}