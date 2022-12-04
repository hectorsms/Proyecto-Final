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
    public class ComprobanteRepository : IComprobanteRepository
    {
        public readonly DB_BUSContext _context;

        public ComprobanteRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comprobante>> GetComprobantes()
        {
            var comprobantes = await _context.Comprobante.ToListAsync();
            return comprobantes;
        }

        public async Task<Comprobante> GetComprobante(int idComprobante)
        {
            return await _context.Comprobante.Where(x => x.IdComprobante == idComprobante).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Comprobante comprobante)
        {
            await _context.Comprobante.AddAsync(comprobante);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Comprobante comprobante)
        {
            _context.Comprobante.Update(comprobante);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int idComprobante)
        {
            var comprobante = await _context.Comprobante.FindAsync(idComprobante);
            if (comprobante == null)
                return false;

            _context.Comprobante.Remove(comprobante);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);

        }


    }
}