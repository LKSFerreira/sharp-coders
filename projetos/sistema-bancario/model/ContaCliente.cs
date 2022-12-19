namespace sistema_bancario
{
    public class ContaCliente : Conta
    {
        public ContaCliente(string titular, string cpf, string senha, double saldo) : base(titular, cpf, senha, saldo)
        {
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                IA.iBank("Por gentileza, digite um valor válido");
            }
            else
            {
                this.Saldo += valor;
            }
        }

        public void Sacar(double valor)
        {
            if (this.Saldo > 0 && valor <= this.Saldo)
            {
                this.Saldo -= valor;
            }
            else
            {
                IA.iBank("Saldo insuficiente");
            }
        }
    }
}