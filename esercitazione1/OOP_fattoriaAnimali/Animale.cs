class Animale
{
    public string nome;
    public int eta;

    public Animale(string nome, int eta)
    {
        this.nome = nome;
        this.eta = eta;
    }

    public virtual void Stampa()
    {
        System.Console.WriteLine("Nome: " + nome);
        System.Console.WriteLine("Eta: " + eta);
    }
}