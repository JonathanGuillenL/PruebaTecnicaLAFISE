using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;
using PruebaTecnicaLAFISE.Infrastructure.Data;

namespace PruebaTecnicaLAFISE.Infrastructure.Repository
{
    public class ComprobanteRepository(ApplicationDbContext context) : IComprobanteRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Comprobante>> FindAllComprobante(CancellationToken cancellation)
        {
            return await _context.Comprobantes.ToListAsync();
        }

        public async Task<Comprobante?> FindComprobanteById(int id, CancellationToken cancellation)
        {
            return await _context.Comprobantes.FirstOrDefaultAsync(c => c.Id == id, cancellation);
        }

        public async Task<Comprobante?> FindCuentaBancariaByNumeroComprobante(string numero, CancellationToken cancellation)
        {
            return await _context.Comprobantes.FirstOrDefaultAsync(c => c.NumeroComprobante == numero, cancellation);
        }

        public async Task SaveComprobante(Comprobante comprobante, CancellationToken cancellation)
        {
            _context.Comprobantes.Add(comprobante);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
