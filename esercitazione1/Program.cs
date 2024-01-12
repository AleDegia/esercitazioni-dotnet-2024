class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        int b = 20;
        if(a > b) //tra le parentesi tonde dell'if c'è la condizione da verificare. se risulta vera, il codice tra le graffe verrà eseguito, altrimenti no
        {
            Console.WriteLine($"{a} è maggiore di {b}");
        } 
        else 
        {
            Console.WriteLine($"{a} è uguale a {b}");
        }
        if (a < b)
        {
            Console.WriteLine($"{a} è minore di {b}");
        }
    }
} 