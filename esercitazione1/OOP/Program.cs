class Program
{
    static void Main(string[] args)
    {
        Persona p = new Persona();
        p.nome = "Mario";
        p.cognome = "Rossi";
        p.eta = 30;

        Persona p2 = new Persona();
        p2.nome = "Luca";
        p2.cognome = "verdi";
        p2.eta = 24;
        
        System.Console.WriteLine("Nome: " + p.nome);
        System.Console.WriteLine("Cognome: " + p.cognome);
        System.Console.WriteLine("Eta: " + p.eta);
        System.Console.WriteLine("Nome persona 2: " + p2.nome);
    }
}