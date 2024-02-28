public class Giocatore
{
    private string? nomeUtente;
    private double balance = 100;
    private int vittorie;
    private int sconfitte;
    private double percentualeVittorie;
    private double percentualeSconfitte;
    private int scelta;
    private int scelta2;

    public string? NomeUtente
    {
        get { return nomeUtente; }
        set { nomeUtente = value; }
    }

    public double Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public int Vittorie
    {
        get { return vittorie; }
        set { vittorie = value; }
    }

    public int Sconfitte
    {
        get { return sconfitte; }
        set { sconfitte = value; }
    }

    public double PercentualeVittorie
    {
        get { return percentualeVittorie; }
        set { percentualeVittorie = value; }
    }

    public double PercentualeSconfitte
    {
        get { return percentualeSconfitte; }
        set { percentualeSconfitte = value; }
    }

    public int Scelta
    {
        get { return scelta; }
        set { scelta = value; }
    }

    public int Scelta2
    {
        get { return scelta2; }
        set { scelta2 = value; }
    }
}
