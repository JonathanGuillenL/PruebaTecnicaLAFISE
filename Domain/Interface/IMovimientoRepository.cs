using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Domain.Interface
{
    public interface IMovimientoRepository
    {
        Task<List<Movimiento>> FindMovimientoByCuentaId(int cuentaId, CancellationToken cancellation);
    }
}
