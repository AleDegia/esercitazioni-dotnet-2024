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
        Random random = new Random(); 
        int index = random.Next(nomi.Length); //genera un numero casuale tra 0 e la lunghezza dell'array di stringhe
        System.Console.WriteLine(nomi[index]); //stampa il nome corrispondente all'indice generato casualmente
        string path2 = @"./test/test2.txt";
        if(!File.Exists(path2))
        {
            File.Create(path2).Close();
        }
        if(!File.ReadAllLines(path2).Contains(nomi[index])) // se il txt non contiene il nome sorteggiato lo aggiunge 
        {
            File.AppendAllText(path2, nomi[index] + "\n"); // \n serve ad aggiungere il nome dopo a capo
        }
        else
        {
            System.Console.WriteLine("il nome è già presente nel file");
        }
    }
}
