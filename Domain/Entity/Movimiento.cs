namespace PruebaTecnicaLAFISE.Domain.Entity
{
    public class Movimiento : BaseAuditoria
    {
        public int Id { get; set; }
        public decimal Momto { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoActual { get; set; }
        public int CuentaBancariaId { get; set; }
        public int TipoMovimientoId { get; set; }
        public string NumeroComprobante { get; set; } = string.Empty;
    }
}
