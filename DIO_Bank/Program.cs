using System;

namespace DIO_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            TipoContaCorrente contaIsaac = new TipoContaCorrente("Isaac",100.0,80.0);
            TipoContaPoupanca contaPIsaac = new TipoContaPoupanca("Isaac",30.0,30.0);
            TipoContaCorrente contaCalebe = new TipoContaCorrente("Calebe",2.0,7.0);
            TipoContaPoupanca contaPCalebe = new TipoContaPoupanca("Calebe",800.0,0.0);
            contaIsaac.Exibe();
            contaIsaac.Depositar(200.0);
            contaIsaac.Exibe();
            contaCalebe.Exibe();
            contaIsaac.Transferir(24.0,contaCalebe);
            contaCalebe.Exibe();
            contaIsaac.Exibe();
            contaPIsaac.Exibe();
            contaIsaac.Transferir(100.0,contaPIsaac);
            contaIsaac.Exibe();
            contaPIsaac.Exibe();
            contaIsaac.Debitar(30.0);
            contaIsaac.Exibe();
            contaPIsaac.Debitar(20.0);
            contaPIsaac.Exibe();

        }
    }
}
