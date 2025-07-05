using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<CuentaBancaria> CuentaBancarias { get; set; }
        public DbSet<TipoMovimiento> TipoMovimientos { get; set; }
    }
}
