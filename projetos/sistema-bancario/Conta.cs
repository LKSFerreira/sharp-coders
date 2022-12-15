namespace sistema_bancario
{
    public class Conta
    {
        private string titular;
        private string senha;
        private string cpf;

        protected Conta(string titular, string senha, string cpf)
        {
            this.titular = titular;
            this.senha = senha;
            this.cpf = cpf;
        }
        protected Conta(string titular, string senha, string cpf, double saldo)
        {
            this.titular = titular;
            this.senha = senha;
            this.cpf = cpf;

        }

        protected string Titular { get => titular; set => titular = value; }
        protected string Senha { get => senha; set => senha = value; }
        protected string Cpf { get => cpf; set => cpf = value; }

    }
}