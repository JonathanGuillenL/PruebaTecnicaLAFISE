using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;
using PruebaTecnicaLAFISE.Infrastructure.Data;

namespace PruebaTecnicaLAFISE.Infrastructure.Repository
{
    public class MovimientoRepository(ApplicationDbContext context) : IMovimientoRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<List<Movimiento>> FindMovimientoByCuentaId(int cuentaId, CancellationToken cancellation)
        {
            return await _context.Movimientos.Where(m => m.CuentaBancariaId == cuentaId).ToListAsync(cancellation);
        }
    }
}
