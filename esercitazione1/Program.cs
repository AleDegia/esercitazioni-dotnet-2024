//Programma che legge un file csv creando un array di stringhe per ogni riga del file e divide ogni riga in un array di
//string utilizzando la virgola come separatore e crea un file csv per ogni riga del file con il nome del file che corrisponde
//al nome della prima colonna ed il contenuto del file che corrisponde al contenuto delle altre colonne disponibili

class Program
{
    static void Main()
    {
        string path = @"test.csv";  //il file deve essere nella stessa cartella del programma
        string [] lines = File.ReadAllLines(path);  //Legge tutte le righe dal file specificato (test.csv) e le memorizza in un array di stringhe chiamato lines. Ogni elemento dell'array rappresenta una riga del file CSV.
        string [][] nomi = new string[lines.Length][]; //crea un array di un array

        for(int i = 0; i < lines.Length; i++)
        {
            nomi[i] = lines[i].Split(','); //assegno ad ogni elemnto dell'array di array di stringhe il valore della riga corrispondente divisa in un array di stringhe utilizzando la virgola ocme separatore
        }

        foreach(string[] nome in nomi)
        {
            string path2 = nome[0] + ".csv";
            File.Create(path2).Close();
            for(int i = 1; i < nome.Length; i++)
            {
                File.AppendAllText(path2, nome[i] + "\n");
            }
        }    
        File.Delete("nome.csv");
    }
}


