using System;

namespace bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {   // construtor
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * (-1)))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;   //this.Saldo = this.Saldo - valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;    //this.Saldo = this.Saldo + valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

        }

        public void Transferir(double valorTransferencia, Conta contaDeposito)
        {
            if (this.Sacar(valorTransferencia)) // verifica se ha saldo na conta do destinatario e saca se true
            {
                contaDeposito.Depositar(valorTransferencia);    // faz a transferencia por meio da funcao deposito
            }
        }

        public override string ToString()
        {   // para fazer um log
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + "\n";
            retorno += "Nome " + this.Nome + "\n";
            retorno += "Saldo " + this.Saldo + "\n";
            retorno += "Crédito " + this.Credito + "\n";

            return retorno;
        }
    }
}