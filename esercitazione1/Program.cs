class Program
{
    static void Main(string[] args)
    {
        string[] nomi = { "Mario", "Luigi", "Giovanni" };

        int i = 0; //variabile contatore inizializzato a zero
        while(i < nomi.Length) //il ciclo continua finchè l'indice p minore della lunghezza dell'array
        {
            System.Console.WriteLine($"Ciao {nomi[i]}");
            i++; //incremento del contatore
        }
    }
}

