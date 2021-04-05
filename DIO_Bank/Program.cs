using System;

namespace DIO_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            TipoContaCorrente contaCorrente = new TipoContaCorrente("Isaac",89.9,87.9);
            contaCorrente.Exibe();
            Console.WriteLine("Hello World!");
        }
    }
}
