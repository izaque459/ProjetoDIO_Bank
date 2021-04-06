namespace DIO_Bank
{
    public static class TipoContrato
    {
        public static bool PessoaFisica(double saldo,double credito)
        {
            if(credito==-10.0)
                return (saldo>10.0);
            else 
                return  ( (saldo>150.0) && (credito >500.0) );
        }

        public static bool PessoaJuridica(double saldo,double credito)
        {
            if(credito==-10.0)
                return (saldo>300.0);
            else
                return ( (saldo>1000.0) && (credito > 3000.0) );
        }
    }
}