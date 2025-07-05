using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Domain.Interface
{
    public interface IComprobanteRepository
    {
        Task<List<Comprobante>> FindAllComprobante(CancellationToken cancellation);
        Task<Comprobante?> FindComprobanteById(int id, CancellationToken cancellation);
        Task<Comprobante?> FindCuentaBancariaByNumeroComprobante(string numero, CancellationToken cancellation);
        Task SaveComprobante(Comprobante comprobante, CancellationToken cancellation);
    }
}
