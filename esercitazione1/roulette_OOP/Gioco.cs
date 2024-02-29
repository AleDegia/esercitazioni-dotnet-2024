public class Gioco
{
    private int[] numeriRoulette = new int[10];

    private double importoScommessa;

    private string? numeroScelto;

    private int[]? arrayNumeriScelti;

    private int quantitaNumeriScelti;

    private int contatore;

    private int numeroDaIndovinare;



    public double ImportoScommessa
    {
        get { return importoScommessa; }
        set { importoScommessa = value; }
    }

    public string NumeroScelto
    {
        get { return numeroScelto; }
        set { numeroScelto = value; }
    }

    public int[] ArrayNumeriScelti
    {
        get { return arrayNumeriScelti; }
        set { arrayNumeriScelti = value; }
    }

    public int QuantitaNumeriScelti
    {
        get { return quantitaNumeriScelti; }
        set { quantitaNumeriScelti = value; }
    }

    public int Contatore
    {
        get { return contatore; }
        set { contatore = value; }
    }

    public int NumeroDaIndovinare
    {
        get { return numeroDaIndovinare; }
        set { numeroDaIndovinare = value; }
    }


}