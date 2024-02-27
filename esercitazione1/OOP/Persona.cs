class Persona
{
    public string nome;
    public string cognome;
    public int eta;

    public Persona(string nome, string cognome, int eta) 
    {
        this.nome = nome;           //this si riferisce all'oggetto creato col new, con cui chiamo il costruttore
        this.cognome = cognome;
        this.eta = eta;
    }

    public void Stampa()
    {
        System.Console.WriteLine("Nome: " + nome);
        System.Console.WriteLine("Cognome: " + cognome);
        System.Console.WriteLine("Eta: " + eta);
    }
}