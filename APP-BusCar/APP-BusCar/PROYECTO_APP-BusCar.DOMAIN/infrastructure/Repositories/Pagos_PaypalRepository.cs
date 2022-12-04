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
    public class Pagos_PaypalRepository : IPagos_PaypalRepository
    {
        private readonly DB_BUSContext _context;

        public Pagos_PaypalRepository(DB_BUSContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PagosPaypal>> GetPagosPaypal()
        {
            var PagosPaypal = await _context.PagosPaypal.ToListAsync();
            return PagosPaypal;
        }
        public async Task<PagosPaypal> GetPagosPaypal(int id)
        {
            return await _context.PagosPaypal.Where(x => x.IdPago == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(PagosPaypal PagosPaypal)
        {
            await _context.PagosPaypal.AddAsync(PagosPaypal);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(PagosPaypal PagosPaypal)
        {
            _context.PagosPaypal.Update(PagosPaypal);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var PagosPaypal = await _context.PagosPaypal.FindAsync(id);
            if (PagosPaypal == null)
                return false;

            _context.PagosPaypal.Remove(PagosPaypal);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}