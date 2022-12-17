using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_bancario
{
    public class ContaCliente : Conta
    {
        public ContaCliente(string cpf, string titular, string senha, double saldo) : base(cpf, titular, senha, saldo)
        {
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                System.Console.WriteLine("Por gentileza, digite um valor válido");
            }
            else
            {
                this.Saldo = valor;
            }
        }

        public void Sacar(double valor)
        {
            if (this.Saldo > 0 && valor <= this.Saldo){
                this.Saldo -= valor;
            } else {
                System.Console.WriteLine("Saldo insuficiente");
            }
        }
    }
}