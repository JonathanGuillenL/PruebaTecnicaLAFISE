using AutoMapper;
using MediatR;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;
using PruebaTecnicaLAFISE.Infrastructure.Repository;

namespace PruebaTecnicaLAFISE.Application.CuentasBancarias.Command
{
    public class CrearCuentaBancariaCommand : IRequest<CuentaBancaria>
    {
        public decimal SaldoInicial { get; set; }
        public int ClienteId { get; set; }
    }

    public class CrearCuentaBancariaCommandHandler : IRequestHandler<CrearCuentaBancariaCommand, CuentaBancaria>
    {
        private readonly ICuentaBancariaRepository _cuentaBancariaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public CrearCuentaBancariaCommandHandler(ICuentaBancariaRepository cuentaBancariaRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            _cuentaBancariaRepository = cuentaBancariaRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<CuentaBancaria> Handle(CrearCuentaBancariaCommand request, CancellationToken cancellationToken)
        {
            Cliente? cliente = await _clienteRepository.FindClienteById(request.ClienteId, cancellationToken);

            if (cliente == null)
            {
                throw new Exception("Cliente no encontrado");
            }

            // validar que no se repita el numero de cuenta
            CuentaBancaria cuentaBancaria = _mapper.Map<CuentaBancaria>(request);

            var random = new Random();
            cuentaBancaria.NumeroCuenta = random.Next(100_000_000, 1_000_000_000).ToString();
            await _cuentaBancariaRepository.SaveCuentaBancaria(cuentaBancaria, cancellationToken);
            return cuentaBancaria;
        }
    }
}
