using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        ContoCorrente contoCorrente = new ContoCorrente("Ale", 1000, 1.2);
        System.Console.WriteLine("conto corrente iniziale: " + contoCorrente.Saldo);
        contoCorrente.Deposita(500);
        System.Console.WriteLine("saldo dopo deposito: " + contoCorrente.Saldo);
        contoCorrente.Preleva(300);
        System.Console.WriteLine("saldo dopo prelielvo: " + contoCorrente.Saldo);
        contoCorrente.CalcolaInteressi();

        
        System.Console.WriteLine("saldo finale: " + contoCorrente.Saldo);
    }
}