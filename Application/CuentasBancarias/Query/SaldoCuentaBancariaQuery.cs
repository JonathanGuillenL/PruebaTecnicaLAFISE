using MediatR;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;

namespace PruebaTecnicaLAFISE.Application.CuentasBancarias.Query
{
    public class SaldoCuentaBancariaQuery : IRequest<CuentaBancaria>
    {
        public required string NumeroCuenta {  get; set; }
    }

    public class SaldoCuentaBancariaQueryHandler : IRequestHandler<SaldoCuentaBancariaQuery, CuentaBancaria>
    {
        private readonly ICuentaBancariaRepository _cuentaBancariaRepository;

        public SaldoCuentaBancariaQueryHandler(ICuentaBancariaRepository cuentaBancariaRepository)
        {
            _cuentaBancariaRepository = cuentaBancariaRepository;
        }

        public async Task<CuentaBancaria> Handle(SaldoCuentaBancariaQuery request, CancellationToken cancellationToken)
        {
            CuentaBancaria? cuentaBancaria = await _cuentaBancariaRepository.FindCuentaBancariaByNumeroCuenta(request.NumeroCuenta, cancellationToken);

            if (cuentaBancaria == null)
            {
                throw new Exception("Numero de cuenta no encontrado");
            }

            return cuentaBancaria;
        }
    }
}
