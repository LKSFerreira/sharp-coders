namespace sistema_bancario
{
    public class ContaFuncionario : Conta
    {
        protected ContaFuncionario(string titular, string senha, string cpf, double saldo) : base(titular, senha, cpf, saldo)
        {

        }
    }
}