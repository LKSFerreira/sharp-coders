namespace sistema_bancario
{
    public class Conta
    {
        private string titular;
        private string senha;
        private string cpf;
        private double saldo;

        protected Conta(string titular,string cpf, string senha, double saldo)
        {
            this.titular = titular;
            this.senha = senha;
            this.cpf = cpf;
            this.saldo = saldo;
        }

        public string Titular { get => titular; set => titular = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public double Saldo { get => saldo; set => saldo = value; }
    }
}