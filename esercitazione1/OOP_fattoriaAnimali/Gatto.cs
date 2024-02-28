class Gatto : Animale
{
    public string colore;
    public Gatto(string nome, int eta, string colore) : base(nome, eta)
    {
        this.colore = colore;
    }

    public override void Stampa()
    {
        base.Stampa();
        System.Console.WriteLine("Colore: " + colore);
    }
}