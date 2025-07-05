using MediatR;
using PruebaTecnicaLAFISE.Domain.Entity;
using PruebaTecnicaLAFISE.Domain.Interface;

namespace PruebaTecnicaLAFISE.Application.Clientes.Query
{
    public class ObtenerClientePorIdQuery : IRequest<Cliente>
    {
        public int Id { get; set; }
    }

    public class ObtenerClientePorIdQueryHandler : IRequestHandler<ObtenerClientePorIdQuery, Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ObtenerClientePorIdQueryHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Handle(ObtenerClientePorIdQuery request, CancellationToken cancellationToken)
        {
            Cliente? cliente = await _clienteRepository.FindClienteById(request.Id, cancellationToken);

            if (cliente == null)
            {
                throw new Exception("Cliente no encontrado");
            }

            return cliente;
        }
    }
}
