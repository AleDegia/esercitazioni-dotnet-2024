class Program
{
    static void Main(string[] args)
    {
        Persona p = new Persona("Mario", "Cognome", 30);
        Persona p2 = new Persona("Luca", "Verdi", 24);
        p.Stampa();
        p2.Stampa();

        //questi cw qui sotto li userei se non avessi il metodo
        
        // System.Console.WriteLine("Nome: " + p.nome);
        // System.Console.WriteLine("Cognome: " + p.cognome);
        // System.Console.WriteLine("Eta: " + p.eta);
        // System.Console.WriteLine("Nome persona 2: " + p2.nome);
    }
}