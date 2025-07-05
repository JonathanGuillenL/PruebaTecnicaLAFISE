namespace PruebaTecnicaLAFISE.Domain.Entity
{
    public class Comprobante : BaseAuditoria
    {
        public int Id { get; set; }
        public string NumeroComprobante => CreatedAt.ToString("yyyyMMdd") + Id.ToString("D5");
        public string Concepto { get; set; } = string.Empty;
        public List<Movimiento> Movimientos { get; set; } = [];
    }
}
