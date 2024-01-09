class Program{
    static void Main(string[] args)
    {
        string nome = "Mario";
        string cognome = "Rossi";
        bool uguali = nome == cognome;
        bool diversi = nome != cognome;
        Console.WriteLine($"I due nomi sono uguali? {uguali}");
        Console.WriteLine($"I due nomi sono diversi? {diversi}");
    }
}