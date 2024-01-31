class Program
{   
    static void Main()
    {
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv"); //legge tutti i file csv nella cartella del programma

        foreach(string file in files)
        {
            System.Console.WriteLine(file); //stampa il nome del file
        }
        System.Console.WriteLine("quale file vuoi eliminare?");
        string fileScelto = Console.ReadLine()!; //legge il nome del file scelto
        string[] lines = File.ReadAllLines(fileScelto); //legge tutte le righe del file
        if(File.Exists(fileScelto)) //controlla se il file scelto esiste
        {
            File.Delete(fileScelto);
        }
        else
        {
            System.Console.WriteLine("il file non esiste");
        }
    }
}


