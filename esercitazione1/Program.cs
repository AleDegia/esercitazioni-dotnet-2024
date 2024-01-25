class Program
{
   

    static void Main(string[] args)
    {
        string path = @"./test/prova.txt"; //il file deve essere nella stessa cartella del programma
        string[] lines = File.ReadAllLines(path); //legge tutte le righe del file
        string[] nomi = new string[lines.Length]; //crea un array di stringhe della lunghezza del numero di righe del file (è = a lines)

        for(int i = 0; i< lines.Length; i++)
        {
            nomi[i] = lines[i]; //assegna ad ogni elemento dell'array di stringhe il valore 
        }

        foreach(string nome in nomi) //per ogni riga
        {
            System.Console.WriteLine(nome); //stampa la riga
        }
    }
}
