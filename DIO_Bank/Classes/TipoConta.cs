using System;

namespace DIO_Bank
{
    public abstract class TipoConta
    {
        protected string Nome { get; set;}
        protected double Saldo{ get; set;}
        protected  double Credito {get; set;}

        protected TipoPessoa TipoPessoa {get; set;}

        public TipoConta(TipoPessoa tipoPessoa, string nome, double saldo, double credito)
        {
            this.Nome = nome;
            this.TipoPessoa = tipoPessoa;
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
            if(this.Saldo >= valorSaque)
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
        private double valorLimite;
        private double taxas{get;set;}
        private double taxaDebito;
        public TipoContaPoupanca(TipoPessoa tipoPessoa, string nome, double saldo, double credito) : base(tipoPessoa,nome, saldo, credito)
        {
            this.taxas=0.0;
            TipoContrato.ParaContaPoupanca(tipoPessoa, out this.taxaDebito, out this.valorLimite );
        }

        public override void Depositar(double valorDeposito)
        {
            base.Depositar(valorDeposito);
        }

        public override void Transferir(double valorTransferencia,TipoConta Destino)
        {
            if(valorTransferencia<=valorLimite)
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
            else
                Saldo-=this.taxaDebito;


        }

        public override string ToString()
		{
            string retorno = null;
            retorno += "Pessoa " + TipoPessoa + " | ";
            retorno += "Nome " + Nome + " | ";
            retorno += "Saldo " + Saldo + " | ";
            retorno += "Crédito " + Credito + " | ";
            retorno += "Taxas " + this.taxas + " | ";
            retorno += "Limite de saque " + this.valorLimite;
			return retorno;
		}
    }

    public class TipoContaCorrente : TipoConta
    {
        private double taxas{get;set;}
        
        private double taxaDebito;
        private double taxaTransferencia;
        
        public TipoContaCorrente(TipoPessoa tipoPessoa,string nome, double saldo, double credito) : base(tipoPessoa,nome, saldo, credito)
        {
            this.taxas=0.0;
            TipoContrato.ParaContaCorrente(tipoPessoa, out this.taxaDebito, out taxaTransferencia);
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
            else
                Saldo-= this.taxaTransferencia;

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
            else
                Saldo-= taxaDebito;

        }

        public override string ToString()
		{
            string retorno = null;
            retorno += "Pessoa " + TipoPessoa + " | ";
            retorno += "Nome " + Nome + " | ";
            retorno += "Saldo " + Saldo + " | ";
            retorno += "Crédito " + Credito + " | ";
            retorno += "Taxas " + this.taxas;
			return retorno;
		}
        
    }
}