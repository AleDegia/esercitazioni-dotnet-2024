class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear(); // Pulisce la console ad ogni iterazione
            Console.WriteLine("Menu di Selezione");
            Console.WriteLine("1. Opzione Uno");
            Console.WriteLine("2. Opzione Due");
            Console.WriteLine("3. Opzione Tre");
            Console.WriteLine("4. Esci");

            Console.Write("Inserisci il numero dell'opzione desiderata: ");
            string input = Console.ReadLine();

            switch (input) 
            {
                case "1": //se il valore della variabile dentro le parentesi tonde dello switch è quello scritto dopo il case, esegue, altrimenti passa al prossimo case
                    Console.WriteLine("Hai selezionato l'Opzione Uno");
                    // Aggiungi qui la logica per l'Opzione Uno
                    break;
                case "2":
                    Console.WriteLine("Hai selezionato l'Opzione Due");
                    // Aggiungi qui la logica per l'Opzione Due
                    break;
                case "3":
                    Console.WriteLine("Hai selezionato l'Opzione Tre");
                    // Aggiungi qui la logica per l'Opzione Tre
                    break;
                case "4":
                    Console.WriteLine("Uscita in corso...");
                    return; // Esce dal programma
                default:
                    Console.WriteLine("Selezione non valida. Riprova.");
                    break;
            }

            Console.WriteLine("Premi un tasto per continuare...");
            Console.ReadKey(); // Aspetta che l'utente prema un tasto prima di continuare
        }
    }
}