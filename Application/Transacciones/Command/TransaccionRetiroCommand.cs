using MediatR;
using Microsoft.VisualBasic;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;

namespace PruebaTecnicaLAFISE.Application.Transacciones.Command
{
    public class TransaccionRetiroCommand : IRequest<Comprobante>
    {
        public required string NumeroCuenta { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; } = string.Empty;
    }

    public class TransaccionRetiroCommandHandler : IRequestHandler<TransaccionRetiroCommand, Comprobante>
    {
        private readonly IComprobanteRepository _comprobanteRepository;
        private readonly ICuentaBancariaRepository _cuentaBancariaRepository;

        public TransaccionRetiroCommandHandler(IComprobanteRepository comprobanteRepository, ICuentaBancariaRepository cuentaBancariaRepository)
        {
            _comprobanteRepository = comprobanteRepository;
            _cuentaBancariaRepository = cuentaBancariaRepository;
        }

        public async Task<Comprobante> Handle(TransaccionRetiroCommand request, CancellationToken cancellationToken)
        {
            CuentaBancaria? cuentaBancaria = await _cuentaBancariaRepository.FindCuentaBancariaByNumeroCuenta(request.NumeroCuenta, cancellationToken);

            if (cuentaBancaria == null)
            {
                throw new Exception("Nùmero de cuenta no encontrado");
            }

            // Verifica si el saldo es menor que el monto a retirar
            if (!cuentaBancaria.tieneFondosSuficientes(request.Monto))
            {
                throw new Exception("Saldo insuficiento para realizar la transacciòn");
            }

            Movimiento movimiento = cuentaBancaria.debitarMonto(request.Monto);

            Comprobante comprobante = new()
            {
                Concepto = request.Concepto
            };
            comprobante.Movimientos.Add(movimiento);

            await _cuentaBancariaRepository.UpdateCuentaBancaria(cuentaBancaria, cancellationToken);
            await _comprobanteRepository.SaveComprobante(comprobante, cancellationToken);

            return comprobante;
        }
    }
}
