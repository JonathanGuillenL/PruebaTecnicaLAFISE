using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaLAFISE.Application.CuentasBancarias.Command;
using PruebaTecnicaLAFISE.Application.CuentasBancarias.Query;
using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Infrastructure.Api
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CuentaBancariaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CuentaBancariaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<CuentaBancaria>> GetByNumeroCuenta([FromQuery] SaldoCuentaBancariaQuery query)
        {
            var cuenta = await _mediator.Send(query);
            return Ok(cuenta);
        }

        [HttpPost]
        public async Task<ActionResult<CuentaBancaria>> Create([FromBody] CrearCuentaBancariaCommand request)
        {
            var cuenta = await _mediator.Send(request);
            return Ok(cuenta);
        }
    }
}
