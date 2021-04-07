namespace DIO_Bank
{
    public static class TipoContrato
    {
        public static void ParaContaCorrente(TipoPessoa tipoPessoa, out double taxaDebito, out double taxaTransferencia)
        {
            switch(tipoPessoa)
            {
                case TipoPessoa.Fisica:
                    taxaDebito = 0.05;
                    taxaTransferencia = 0.1;
                    break;
                case TipoPessoa.Juridica:
                    taxaDebito = 0.02;
                    taxaTransferencia = 0.05;
                    break;
                default:
                    taxaDebito = 0.0;
                    taxaTransferencia = 0.0;
                    break;
            }
        }

        public static void ParaContaPoupanca(TipoPessoa tipoPessoa, out double taxaDebito, out double valorLimite)
        {
            switch(tipoPessoa)
            {
                case TipoPessoa.Fisica:
                    taxaDebito = 0.1;
                    valorLimite = 150.0;
                    break;
                case TipoPessoa.Juridica:
                    taxaDebito = 0.05;
                    valorLimite = 300.0;
                    break;
                default:
                    taxaDebito = 0.0;
                    valorLimite = 0.0;
                    break;
            }
        }
    }
}