namespace PruebaTecnicaLAFISE.Domain.Entity
{
    public abstract class BaseAuditoria
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
