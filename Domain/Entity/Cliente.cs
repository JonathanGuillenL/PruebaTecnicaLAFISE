namespace PruebaTecnicaLAFISE.Domain.Entity
{
    public class Cliente : BaseAuditoria
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }
        public decimal Ingresos { get; set; }
    }
}
