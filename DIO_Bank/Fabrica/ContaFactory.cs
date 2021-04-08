namespace DIO_Bank
{
    public class ContaFactory
    {
        public TipoConta GetConta(int i,TipoPessoa tipoPessoa,string nome,double saldo,double credito)
        { 
            TipoConta retorno = null;
            if(i==1)
                retorno = new TipoContaPoupanca(tipoPessoa,nome,saldo,credito);
            else if(i==2)
                retorno = new TipoContaCorrente(tipoPessoa,nome,saldo,credito);
            
            return retorno;
        }
    }
}