using System;

namespace DIO_Bank
{
    public abstract class TipoConta
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

        public virtual  void Depositar(double valorDeposito)
        {
            this.Saldo+=valorDeposito;
        }
        public virtual void Transferir(double valorTransferencia,TipoConta Destino)
        {
            if(Sacar(valorTransferencia))
                Destino.Depositar(valorTransferencia);
        }
        public virtual bool Sacar(double valorSaque)
        {
            if(Saldo > valorSaque)
            {   
                Saldo-=valorSaque;
                return true;
            }
            else 
                return false;
        }
    }

    public class TipoContaPoupanca : TipoConta
    {
        private double valorLimite;
        public TipoContaPoupanca(string nome, double saldo, double credito) : base(nome, saldo, credito)
        {
            this.valorLimite = 300.0;
        }

        public override void Depositar(double valorDeposito)
        {
            base.Depositar(valorDeposito);
        }

        public override void Transferir(double valorTransferencia,TipoConta Destino)
        {
            base.Transferir(valorTransferencia,Destino);
        }

        public override bool Sacar(double valorSaque)
        {
            if(valorSaque<=valorLimite)
                return base.Sacar(valorSaque);
            else
                return false;
        }

        public void Exibe()
        {
            Console.WriteLine($"nome: {Nome}, saldo: {Saldo}, credito: {Credito}, valor de limite {valorLimite}");
        }
    }

    public class TipoContaCorrente : TipoConta
    {
        private double taxas;
        public TipoContaCorrente(string nome, double saldo, double credito) : base(nome, saldo, credito)
        {
            this.taxas=0.0;
        }

        public override void Depositar(double valorDeposito)
        {
            base.Depositar(valorDeposito);
        }

        public override void Transferir(double valorTransferencia,TipoConta Destino)
        {
            taxas+=Saldo*0.05;
            Saldo-= taxas;
            base.Transferir(valorTransferencia,Destino);
        }

        public override bool Sacar(double valorSaque)
        {
            return base.Sacar(valorSaque);
        }
        public void Exibe()
        {
            Console.WriteLine($"nome: {Nome}, saldo: {Saldo}, credito: {Credito}, taxas: {taxas}");
        }
    }
}