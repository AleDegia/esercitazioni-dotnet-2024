class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Premi 'N' per terminare");

        //ciclo che continua fino a quando non viene prenmuto il tasto N 
        while(true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(); //Questa riga legge il tasto premuto dall'utente e salva le informazioni su di esso in una variabile keyInfo di tipo ConsoleKeyInfo.
            if (keyInfo.Key == ConsoleKey.N) //Qui viene verificato se il tasto premuto è 'N'. Se sì, il ciclo while viene interrotto usando l'istruzione break, portando alla fine del programma.
            {
                break;
            }
        }
    }
}
