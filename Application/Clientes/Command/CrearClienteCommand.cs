using AutoMapper;
using MediatR;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;

namespace PruebaTecnicaLAFISE.Application.Clientes.Command
{
    public class CrearClienteCommand : IRequest<Cliente>
    {
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }
        public decimal Ingresos { get; set; }
    }

    public class CrearClienteCommandHandler : IRequestHandler<CrearClienteCommand, Cliente>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public CrearClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<Cliente> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente cliente = _mapper.Map<Cliente>(request);
            await _clienteRepository.SaveCliente(cliente, cancellationToken);

            return cliente;
        }
    }
}
