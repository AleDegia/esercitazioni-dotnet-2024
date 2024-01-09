class Program
{
    static void Main(string[] args)
    {
        string nome = "Alessandro";
        string cognome = "Deg";
        Console.WriteLine("Ciao " + nome); //concatenazione
        Console.WriteLine($"Ciao {nome}"); //interpolazione di stringhe ( col + è concatenazione)
        Console.WriteLine($"Ciao {nome} {cognome}");
    }
}