﻿namespace PruebaTecnicaLAFISE.Domain.Entity
{
    public class TipoMovimiento : BaseAuditoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
