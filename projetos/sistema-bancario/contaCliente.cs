using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistema_bancario
{
    public class contaCliente : Conta
    {
        private double saldo = 0;

        public contaCliente(string titular, string senha, string cpf) : base(titular, senha, cpf)
        {
        }

        public contaCliente(string titular, string senha, string cpf, double saldo) : base(titular, senha, cpf, saldo)
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
                saldo = valor;
            }
        }

        public void Sacar(double valor)
        {
            if (saldo > 0 && valor <= saldo){
                saldo -= valor;
            } else {
                System.Console.WriteLine("Saldo insuficiente");
            }
        }
    }
}