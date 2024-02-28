public class ContoBancario
{
    private string nome;
    private double saldo;

    // public double GetSaldo()
    // {
    //     return saldo;
    // }

    // public void SetSaldo(double value)
    // {
    //     saldo = value;
    // }

    public double Saldo
    {
        get { return saldo; }
        set { saldo = value; }
    }

    public ContoBancario(string nome, double saldo)
    {
        this.nome = nome;
        this.saldo = saldo;
    }

    public void Deposita(double importo)
    {
        saldo += importo;
    }

    public void Preleva(double importo)
    {
        saldo -= importo;
    }

    public void Stampa()
    {
        System.Console.WriteLine("Nome: " + nome);
        System.Console.WriteLine("Saldo: " + saldo);
    }

    
}