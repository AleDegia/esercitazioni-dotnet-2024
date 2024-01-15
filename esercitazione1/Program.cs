class Program //aggiungere case name con variabile con nostro nome, quando facciamo case name stampi il nostro nome
{
    static void Main(string[] args)
    {
        //System.Console.WriteLine("Trascina un file qui e premi invio");
        //string filePath = Console.ReadLine().Trim('"'); //creo il percorso per aprire il file, rimuovendo le virgolette che possono apparire nel percorso
        string filePath = "C:/Users/DOTNET/Documents/Corso-Dotnet-2024/CORSO-DOTNET-2024/esercitazioni-dotnet-2024/esercitazione1/prova.txt";
        
        try
        {
            string content = File.ReadAllText(filePath); //legge tutte le righe del file e le memorizza nella stringa content
            System.Console.WriteLine("Contenuto del file:");
            System.Console.WriteLine(content);
        }
        catch(Exception ex)
        {
            System.Console.WriteLine($"Si è verificato un errore: {ex.Message}");
        }
    }
}

/*
Le virgolette intorno al percorso del file vengono considerate quando si trascina un file in una console su alcuni sistemi operativi.
 Questo comportamento può variare a seconda del sistema operativo e del modo in cui la console gestisce gli spazi nei percorsi dei file.
 */