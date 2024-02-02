class Program
{
    static void Main()
    {
       System.Console.WriteLine("Inserisci un numero");
       int numero = int.Parse(Console.ReadLine()!);
       StampaPari(numero);
       System.Console.WriteLine("Inserisci un altro numero");
       numero = int.Parse(Console.ReadLine()!);
       StampaPari(numero);
    }

    static bool Pari(int numeroArgomento)
    {
        return numeroArgomento % 2 == 0; //il questo caso il metodo Pari restituisce un valore booleano 
    }

    static void StampaPari(int numeroArgomento)
    {
        if(Pari(numeroArgomento))
        {
            System.Console.WriteLine("Il numero è pari");
        }
        else
        {
            System.Console.WriteLine("Il numero è dispari");
        }
    }
}