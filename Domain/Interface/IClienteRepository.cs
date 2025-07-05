using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Domain.Interface
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> FindAllClientes(CancellationToken cancellation);
        Task<Cliente?> FindClienteById(int id, CancellationToken cancellation);
        Task SaveCliente(Cliente cliente, CancellationToken cancellation);
        Task DeleteCliente(Cliente cliente, CancellationToken cancellation);
    }
}
