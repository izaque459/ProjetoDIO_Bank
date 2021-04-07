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
            if(saldo>0.0)
                this.Saldo = saldo;
            else
                this.Saldo = 0.0;
            if(credito>0.0)
                this.Credito = credito;
            else
                this.Credito = 0.0;
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
            if(this.Saldo > valorSaque)
            {   
                this.Saldo-=valorSaque;
                return true;
            }
            else 
                return false;
        }

        public virtual void Debitar(double debito)
        {
            if(this.Credito>debito)
                this.Credito -= debito;
        }
    }

    public class TipoContaPoupanca : TipoConta
    {
        private double valorLimite{get;set;}
        private double taxas{get;set;}
        private double taxaDebito{get;set;}
        public TipoContaPoupanca(string nome, double saldo, double credito) : base(nome, saldo, credito)
        {
            this.valorLimite = 300.0;
            this.taxas=0.0;
            this.taxaDebito=0.05;
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

        public override void Debitar(double debito)
        {
            base.Debitar(debito);
            if(Saldo>1.0)
            {
                this.taxas+=this.taxaDebito;
                Saldo-=this.taxaDebito;
            }

        }
        public void Exibe()
        {
            Console.WriteLine($"nome: {Nome}, saldo: {Saldo}, credito: {Credito},taxas: {taxas}, limite de saque {valorLimite}");
        }
    }

    public class TipoContaCorrente : TipoConta
    {
        private double taxas{get;set;}
        
        private double taxaDebito{get;set;}
        private double taxaTransferencia{get;set;}
        
        public TipoContaCorrente(string nome, double saldo, double credito) : base(nome, saldo, credito)
        {
            this.taxas=0.0;
            this.taxaTransferencia=0.1;
            this.taxaDebito=0.05;
        }

        public override void Depositar(double valorDeposito)
        {
            base.Depositar(valorDeposito);
        }

        public override void Transferir(double valorTransferencia,TipoConta Destino)
        {
            base.Transferir(valorTransferencia,Destino);
            if(Saldo>1.0)
            {
                this.taxas+= this.taxaTransferencia;
                Saldo-= this.taxaTransferencia;
            }
        }

        public override bool Sacar(double valorSaque)
        {
            return base.Sacar(valorSaque);
        }

        public override void Debitar(double debito)
        {
            base.Debitar(debito);
            if(Saldo>1.0)
            {
                taxas+=Saldo*taxaDebito;
                Saldo-= Saldo*taxaDebito;
            }
        }

        public void Exibe()
        {
            Console.WriteLine($"nome: {Nome}, saldo: {Saldo}, credito: {Credito}, taxas: {taxas}");
        }
    }
}