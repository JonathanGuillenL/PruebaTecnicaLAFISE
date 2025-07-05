using MediatR;
using PruebaTecnicaLAFISE.Application.Dtos;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;

namespace PruebaTecnicaLAFISE.Application.Transacciones.Query
{
    public class TransaccionResumenQuery : IRequest<ResumenTransaccionesResponseDto>
    {
        public required string NumeroCuenta { get; set; }
    }

    public class TransaccionResumenQueryHandler : IRequestHandler<TransaccionResumenQuery, ResumenTransaccionesResponseDto>
    {
        private readonly ICuentaBancariaRepository _cuentaBancariaRepository;
        private readonly IMovimientoRepository _movimientoRepository;

        public TransaccionResumenQueryHandler(ICuentaBancariaRepository cuentaBancariaRepository, IMovimientoRepository movimientoRepository)
        {
            _cuentaBancariaRepository = cuentaBancariaRepository;
            _movimientoRepository = movimientoRepository;
        }

        public async Task<ResumenTransaccionesResponseDto> Handle(TransaccionResumenQuery request, CancellationToken cancellationToken)
        {
            CuentaBancaria? cuenta = await _cuentaBancariaRepository.FindCuentaBancariaByNumeroCuenta(request.NumeroCuenta, cancellationToken);

            if (cuenta == null)
            {
                throw new Exception("Nùmero de cuenta no encontrado");
            }

            List<Movimiento> movimiento = await _movimientoRepository.FindMovimientoByCuentaId(cuenta.Id, cancellationToken);

            return new ResumenTransaccionesResponseDto
            {
                CuentaBancariaId = cuenta.Id,
                NumeroCuenta = cuenta.NumeroCuenta,
                Saldo = cuenta.Saldo,
                Cliente = cuenta.Cliente,
                Movimientos = movimiento
            };
        }
    }
}
