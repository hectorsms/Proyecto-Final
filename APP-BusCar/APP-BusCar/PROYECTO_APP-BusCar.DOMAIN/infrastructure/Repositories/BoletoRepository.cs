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
    public class BoletoRepository : IBoletoRepository


    {
        private readonly DB_BUSContext _context;
        public BoletoRepository(DB_BUSContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Boleto>> getBoletos()
        {
            var boletos = await _context.Boleto.ToListAsync();
            return boletos;
        }

        public async Task<Boleto> GetBoleto(int id)
        {
            return await _context.Boleto.Where(x => x.IdBoleto == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Boleto boleto)
        {
            await _context.Boleto.AddAsync(boleto);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Boleto boleto)
        {
            _context.Boleto.Update(boleto);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var boleto = await _context.Boleto.FindAsync(id);
            if (boleto == null)
                return false;
            _context.Boleto.Remove(boleto);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}