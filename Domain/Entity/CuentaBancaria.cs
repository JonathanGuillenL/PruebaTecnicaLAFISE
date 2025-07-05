namespace PruebaTecnicaLAFISE.Domain.Entity
{
    public class CuentaBancaria : BaseAuditoria
    {
        public int Id { get; set; }
        public string NumeroCuenta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public int ClienteId { get; set; }

        public required Cliente Cliente { get; set; }

        public Boolean tieneFondosSuficientes(decimal cantidad)
        {
            return Saldo >= cantidad;
        }

        public Movimiento debitarMonto(decimal monto)
        {
            decimal saldoActual = this.Saldo - monto;
            Movimiento movimiento = new Movimiento
            {
                CuentaBancariaId = this.Id,
                SaldoAnterior = this.Saldo,
                SaldoActual = saldoActual,
                Momto = monto
            };

            this.Saldo = saldoActual;
            return movimiento;
        }

        public Movimiento acreditarMonto(decimal monto)
        {
            decimal saldoActual = this.Saldo + monto;
            Movimiento movimiento = new Movimiento
            {
                CuentaBancariaId = this.Id,
                SaldoAnterior = this.Saldo,
                SaldoActual = saldoActual,
                Momto = monto
            };

            this.Saldo = saldoActual;
            return movimiento;
        }
    }
}
