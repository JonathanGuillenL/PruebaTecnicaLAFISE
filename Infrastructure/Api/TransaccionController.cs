using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaLAFISE.Application.Dtos;
using PruebaTecnicaLAFISE.Application.Transacciones.Command;
using PruebaTecnicaLAFISE.Application.Transacciones.Query;

namespace PruebaTecnicaLAFISE.Infrastructure.Api
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private IMediator _mediator;

        public TransaccionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("resumen")]
        public async Task<ActionResult<ResumenTransaccionesResponseDto>> Resumen([FromQuery] TransaccionResumenQuery query)
        {
            var resumen = await _mediator.Send(query);
            return Ok(resumen);
        }

        [HttpPost("deposito")]
        public async Task<IActionResult> Deposito([FromBody] TransaccionDepositoCommand request)
        {
            var comprobante = await _mediator.Send(request);
            return Ok(comprobante);
        }

        [HttpPost("retiro")]
        public async Task<IActionResult> Retiro([FromBody] TransaccionRetiroCommand request)
        {
            var comprobante = await _mediator.Send(request);
            return Ok(comprobante);
        }
    }
}
