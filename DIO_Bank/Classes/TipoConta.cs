using System;

namespace DIO_Bank
{
    public class TipoConta
    {
        protected string Nome { get; set;}
        protected double Saldo{ get; set;}
        protected  double Credito {get; set;}

        public TipoConta(string nome, double saldo, double credito)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }
    }

    public class TipoContaPoupanca : TipoConta
    {
        private bool TipoContrato TipoContrato {get; set;}
        public TipoContaPoupanca(string nome, double saldo, double credito) : base(nome, saldo, credito)
        {
        }
    }

    public class TipoContaCorrente : TipoConta
    {
        private bool TipoContrato TipoContrato {get; set;}

        public TipoContaCorrente(string nome, double saldo, double credito) : base(nome, saldo, credito)
        {
        }
        public void Exibe()
        {
            Console.WriteLine($"nome: {Nome}, saldo: {Saldo}, credito: {Credito}");
        }
    }
}