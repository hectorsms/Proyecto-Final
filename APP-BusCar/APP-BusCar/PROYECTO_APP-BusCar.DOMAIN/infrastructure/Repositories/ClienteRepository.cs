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
    public class ClienteRepository : IClienteRepository
    {
        private readonly DB_BUSContext _context;

        public ClienteRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = await _context.Cliente.ToListAsync();
            return clientes;
        }

        public async Task<Cliente> GetCliente(int idCliente)
        {
            return await _context.Cliente.Where(x => x.IdCliente == idCliente).FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetClienteDoc(int idDocumento, string dni)
        {
            return await _context.Cliente.Where(x => x.IdDocumento == idDocumento && x.Dni == dni).FirstOrDefaultAsync();
        }


        public async Task<bool> Insert(Cliente cliente)
        {
            await _context.Cliente.AddAsync(cliente);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int idCliente)
        {
            var cliente = await _context.Cliente.FindAsync(idCliente);
            if (cliente == null)
                return false;

            _context.Cliente.Remove(cliente);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);

        }

    }
}


