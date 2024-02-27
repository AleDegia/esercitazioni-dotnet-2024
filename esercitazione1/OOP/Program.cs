class Persona
{
    private string nome;            //non puo accederci nessun altra classe se non persona
    private string cognome;
    private int eta;

    public string Nome
    {
        get{return nome;}
        set{nome = value;}
    }

    public string Cognome
    {
        get{return cognome;}
        set{cognome = value;}
    }

    public int Eta
    {
        get{return eta;}
        set{eta = value;}
    }

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