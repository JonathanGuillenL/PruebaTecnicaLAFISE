using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;
using PruebaTecnicaLAFISE.Infrastructure.Data;

namespace PruebaTecnicaLAFISE.Infrastructure.Repository
{
    public class CuentaBancariaRepository(ApplicationDbContext context) : ICuentaBancariaRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<CuentaBancaria>> FindAllCuentasBancarias(CancellationToken cancellation)
        {
            return await _context.CuentaBancarias.ToListAsync(cancellation);
        }

        public async Task<CuentaBancaria?> FindCuentaBancariaById(int id, CancellationToken cancellation)
        {
            return await _context.CuentaBancarias.FirstOrDefaultAsync(c => c.Id == id, cancellation);
        }

        public async Task<CuentaBancaria?> FindCuentaBancariaByNumeroCuenta(string numero, CancellationToken cancellation)
        {
            return await _context.CuentaBancarias.FirstOrDefaultAsync(c => c.NumeroCuenta == numero, cancellation);
        }

        public async Task SaveCuentaBancaria(CuentaBancaria cuentaBancaria, CancellationToken cancellation)
        {
            _context.CuentaBancarias.Add(cuentaBancaria);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task UpdateCuentaBancaria(CuentaBancaria cuentaBancaria, CancellationToken cancellation)
        {
            _context.CuentaBancarias.Update(cuentaBancaria);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
