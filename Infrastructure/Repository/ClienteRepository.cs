using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;
using PruebaTecnicaLAFISE.Infrastructure.Data;

namespace PruebaTecnicaLAFISE.Infrastructure.Repository
{
    public class ClienteRepository(ApplicationDbContext context) : IClienteRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task DeleteCliente(Cliente cliente, CancellationToken cancellation)
        {
            cliente.DeletedAt = DateTime.Now;
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync(cancellation);
        }

        public async Task<List<Cliente>> FindAllClientes(CancellationToken cancellation)
        {
            return await _context.Clientes.ToListAsync(cancellation);
        }

        public async Task<Cliente?> FindClienteById(int id, CancellationToken cancellation)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id, cancellation);
        }

        public async Task SaveCliente(Cliente cliente, CancellationToken cancellation)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
