using MediatR;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;

namespace PruebaTecnicaLAFISE.Application.Transacciones.Command
{
    public class TransaccionDepositoCommand : IRequest<Comprobante>
    {
        public string? NumeroCuentaOrigen { get; set; } = null;
        public required string NumeroCuentaDestino{ get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; } = string.Empty;
    }

    public class TransaccionDepositoCommandHandler : IRequestHandler<TransaccionDepositoCommand, Comprobante>
    {
        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly ICuentaBancariaRepository _cuentaBancariaRepository;

        public TransaccionDepositoCommandHandler(IComprobanteRepository comprobanteRepository, ICuentaBancariaRepository cuentaBancariaRepository)
        {
            _comprobanteRepository = comprobanteRepository;
            _cuentaBancariaRepository = cuentaBancariaRepository;
        }

        public async Task<Comprobante> Handle(TransaccionDepositoCommand request, CancellationToken cancellationToken)
        {
            Comprobante comprobante = new Comprobante
            {
                Concepto = request.Concepto
            };

            if (request.NumeroCuentaOrigen != null)
            {
                CuentaBancaria? cuentaOrigen = await _cuentaBancariaRepository.FindCuentaBancariaByNumeroCuenta(request.NumeroCuentaOrigen, cancellationToken);

                if (cuentaOrigen == null)
                {
                    throw new Exception("Nùmero de cuenta no encontrado");
                }

                if (!cuentaOrigen.tieneFondosSuficientes(request.Monto))
                {
                    throw new Exception("Saldo insuficiento para realizar la transacciòn");
                }

                comprobante.Movimientos.Add(cuentaOrigen.debitarMonto(request.Monto));

                await _cuentaBancariaRepository.UpdateCuentaBancaria(cuentaOrigen, cancellationToken);
            }

            CuentaBancaria? cuentaDestino = await _cuentaBancariaRepository.FindCuentaBancariaByNumeroCuenta(request.NumeroCuentaDestino, cancellationToken);

            if (cuentaDestino == null)
            {
                throw new Exception("Nùmero de cuenta no encontrado");
            }

            comprobante.Movimientos.Add(cuentaDestino.acreditarMonto(request.Monto));

            await _cuentaBancariaRepository.UpdateCuentaBancaria(cuentaDestino, cancellationToken);

            await _comprobanteRepository.SaveComprobante(comprobante, cancellationToken);

            return comprobante;
        }
    }
}
