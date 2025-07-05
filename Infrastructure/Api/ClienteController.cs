using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaLAFISE.Application.Clientes.Command;
using PruebaTecnicaLAFISE.Application.Clientes.Query;
using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Infrastructure.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById([FromRoute] int id)
        {
            var cliente = await _mediator.Send(new ObtenerClientePorIdQuery { Id = id });
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearClienteCommand request)
        {
            var cliente = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }
    }
}
