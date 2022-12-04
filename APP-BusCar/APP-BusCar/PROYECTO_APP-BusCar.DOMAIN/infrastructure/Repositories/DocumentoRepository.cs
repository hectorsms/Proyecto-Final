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
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly DB_BUSContext _context;

        public DocumentoRepository(DB_BUSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Documento>> GetDocumentos()
        {
            var documentos = await _context.Documento.ToListAsync();
            return documentos;
        }
        public async Task<Documento> GetDocumento(int id)
        {
            return await _context.Documento.Where(x => x.IdDocumento == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Documento documento)
        {
            await _context.Documento.AddAsync(documento);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Update(Documento documento)
        {
            _context.Documento.Update(documento);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var documento = await _context.Documento.FindAsync(id);
            if (documento == null)
                return false;

            _context.Documento.Remove(documento);
            var countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

    }
}