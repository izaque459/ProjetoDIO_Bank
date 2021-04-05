namespace DIO_Bank
{
    public static class TipoContrato
    {
        public static bool PessoaFisica(double saldo,double credito)
        {
            return  ( (saldo>10) && (credito >500) );
        }

        public static bool PessoaJuridica(double saldo,double credito)
        {
            return ( (saldo>200) && (credito > 3000) );
        }
    }
}