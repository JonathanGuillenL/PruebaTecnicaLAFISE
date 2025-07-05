using PruebaTecnicaLAFISE.Domain.Entity;

namespace PruebaTecnicaLAFISE.Application.Dtos
{
    public class ResumenTransaccionesResponseDto
    {
        public int CuentaBancariaId { get; set; }
        public string NumeroCuenta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public required Cliente Cliente { get; set; }
        public required List<Movimiento> Movimientos { get; set; }
    }
}
