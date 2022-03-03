using System;

namespace Bank
{
    public class conta
    {
        private tipo tipo { get; set;}
        private Double saldo {get; set;}
        private Double credito {get; set;}
        private string nome {get; set;}

        public conta(tipo tipo, double saldo, double credito, string nome)
        {
            this.tipo = tipo;
            this.saldo = saldo;
            this.credito = credito;
            this.nome = nome;
        }
        
        public bool Sacar(double valorsacar)
        {
            if(this.saldo - valorsacar < (this.credito *-1)){
               Console.WriteLine("O saldo não é suficiente!");
               return false;
            }
            this.saldo = this.saldo - valorsacar;

            Console.WriteLine("O saldo de {0} é {1}", this.nome, this.saldo);

            return true;
        }

        public void Depositar(double valordepositar)
        {
            this.saldo = this.saldo + valordepositar;

            Console.WriteLine("O saldo de {0} é {1}", this.nome, this.saldo);
            
        }
        
        public void Transferir(double valortransferir, conta contadestino)
        {
            if(this.Sacar(valortransferir)){
                contadestino.Depositar(valortransferir);
            }
        }
        public bool Doar(double valordoar)
        {
            if(this.saldo - valordoar < (this.credito *-1)){
               Console.WriteLine("O saldo não é suficiente!");
               return false;
            }
            this.saldo = this.saldo - valordoar;

            Console.WriteLine("O saldo de {0} é: {1}", this.nome, this.saldo);

            return true;
        }

        public void Emprestimos(double valoremprestar)
        {
            this.credito = this.credito + valoremprestar;

            Console.WriteLine("\nConta: {0} \nSaldo: {1} \nCréditos: {2}", this.nome, this.saldo, this.credito);
            Console.WriteLine("O valor de empréstimo requisitado foi: {0}", valoremprestar);
        }

        public override string ToString()
		{
            string retorno = "";
            retorno += "Tipo de conta: " + this.tipo + " | ";
            retorno += "Nome: " + this.nome + " | ";
            retorno += "Saldo: " + this.saldo + " | ";
            retorno += "Crédito: " + this.credito;
			return retorno;
		}
    }
}