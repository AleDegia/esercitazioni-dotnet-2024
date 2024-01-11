class Program{
    static void Main(string[] args)
    {
        int[] numeri = new int[3];
        numeri[0] = 10;
        numeri[1] = 20; 
        numeri[2] = Int32.Parse("30"); //conversione da string a int
        
        Console.WriteLine($"Ciao {numeri[0]}, {numeri[1]} e {numeri[2]}");
    }
}

