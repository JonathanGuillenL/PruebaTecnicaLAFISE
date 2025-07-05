using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Domain.Interface
{
    public interface ICuentaBancariaRepository
    {
        Task<List<CuentaBancaria>> FindAllCuentasBancarias(CancellationToken cancellation);
        Task<CuentaBancaria?> FindCuentaBancariaById(int id, CancellationToken cancellation);
        Task<CuentaBancaria?> FindCuentaBancariaByNumeroCuenta(string numero, CancellationToken cancellation);
        Task SaveCuentaBancaria(CuentaBancaria cuentaBancaria, CancellationToken cancellation);
        Task UpdateCuentaBancaria(CuentaBancaria cuentaBancaria, CancellationToken cancellation);
    }
}
