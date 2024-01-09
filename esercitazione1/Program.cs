class Program{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 10;
        bool maggiore = a > b;
        bool minoreOuguale = a <= b;
        
        Console.WriteLine($"Il primo numero è maggiore del secondo? {maggiore}");
        Console.WriteLine($"Il primo numero è minore o uguale rispetto al secondo? {minoreOuguale}");
    }
}