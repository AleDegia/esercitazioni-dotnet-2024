class Cane : Animale
{
    public string razza;

    public Cane(string nome, int eta, string razza) : base(nome, eta)
    {
        this.razza = razza;
    }

    public override void Stampa()
    {
        base.Stampa();
        System.Console.WriteLine("Razza " + razza);
    }
}

